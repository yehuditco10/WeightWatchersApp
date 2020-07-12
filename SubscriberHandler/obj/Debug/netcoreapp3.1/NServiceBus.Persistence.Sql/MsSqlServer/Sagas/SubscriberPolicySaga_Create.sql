
/* TableNameVariable */

declare @tableName nvarchar(max) = '[' + @schema + '].[' + @tablePrefix + N'SubscriberPolicySaga]';
declare @tableNameWithoutSchema nvarchar(max) = @tablePrefix + N'SubscriberPolicySaga';


/* Initialize */

/* CreateTable */

if not exists
(
    select *
    from sys.objects
    where
        object_id = object_id(@tableName) and
        type in ('U')
)
begin
declare @createTable nvarchar(max);
set @createTable = '
    create table ' + @tableName + '(
        Id uniqueidentifier not null primary key,
        Metadata nvarchar(max) not null,
        Data nvarchar(max) not null,
        PersistenceVersion varchar(23) not null,
        SagaTypeVersion varchar(23) not null,
        Concurrency int not null
    )
';
exec(@createTable);
end

/* AddProperty measureId */

if not exists
(
  select * from sys.columns
  where
    name = N'Correlation_measureId' and
    object_id = object_id(@tableName)
)
begin
  declare @createColumn_measureId nvarchar(max);
  set @createColumn_measureId = '
  alter table ' + @tableName + N'
    add Correlation_measureId bigint;';
  exec(@createColumn_measureId);
end

/* VerifyColumnType Int */

declare @dataType_measureId nvarchar(max);
set @dataType_measureId = (
  select data_type
  from INFORMATION_SCHEMA.COLUMNS
  where
    table_name = @tableNameWithoutSchema and
    table_schema = @schema and
    column_name = 'Correlation_measureId'
);
if (@dataType_measureId <> 'bigint')
  begin
    declare @error_measureId nvarchar(max) = N'Incorrect data type for Correlation_measureId. Expected bigint got ' + @dataType_measureId + '.';
    throw 50000, @error_measureId, 0
  end

/* WriteCreateIndex measureId */

if not exists
(
    select *
    from sys.indexes
    where
        name = N'Index_Correlation_measureId' and
        object_id = object_id(@tableName)
)
begin
  declare @createIndex_measureId nvarchar(max);
  set @createIndex_measureId = N'
  create unique index Index_Correlation_measureId
  on ' + @tableName + N'(Correlation_measureId)
  where Correlation_measureId is not null;';
  exec(@createIndex_measureId);
end

/* PurgeObsoleteIndex */

declare @dropIndexQuery nvarchar(max);
select @dropIndexQuery =
(
    select 'drop index ' + name + ' on ' + @tableName + ';'
    from sysindexes
    where
        Id = object_id(@tableName) and
        Name is not null and
        Name like 'Index_Correlation_%' and
        Name <> N'Index_Correlation_measureId'
);
exec sp_executesql @dropIndexQuery

/* PurgeObsoleteProperties */

declare @dropPropertiesQuery nvarchar(max);
select @dropPropertiesQuery =
(
    select 'alter table ' + @tableName + ' drop column ' + column_name + ';'
    from INFORMATION_SCHEMA.COLUMNS
    where
        table_name = @tableNameWithoutSchema and
        table_schema = @schema and
        column_name like 'Correlation_%' and
        column_name <> N'Correlation_measureId'
);
exec sp_executesql @dropPropertiesQuery

/* CompleteSagaScript */
