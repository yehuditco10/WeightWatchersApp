
/* TableNameVariable */

/* Initialize */

/* CreateTable */

create or replace function pg_temp.create_saga_table_SubscriberPolicySaga(tablePrefix varchar, schema varchar)
    returns integer as
    $body$
    declare
        tableNameNonQuoted varchar;
        script text;
        count int;
        columnType varchar;
        columnToDelete text;
    begin
        tableNameNonQuoted := tablePrefix || 'SubscriberPolicySaga';
        script = 'create table if not exists "' || schema || '"."' || tableNameNonQuoted || '"
(
    "Id" uuid not null,
    "Metadata" text not null,
    "Data" jsonb not null,
    "PersistenceVersion" character varying(23),
    "SagaTypeVersion" character varying(23),
    "Concurrency" int not null,
    primary key("Id")
);';
        execute script;

/* AddProperty measureId */

        script = 'alter table "' || schema || '"."' || tableNameNonQuoted || '" add column if not exists "Correlation_measureId" integer';
        execute script;

/* VerifyColumnType Int */

        columnType := (
            select data_type
            from information_schema.columns
            where
            table_schema = schema and
            table_name = tableNameNonQuoted and
            column_name = 'Correlation_measureId'
        );
        if columnType <> 'integer' then
            raise exception 'Incorrect data type for Correlation_measureId. Expected "integer" got "%"', columnType;
        end if;

/* WriteCreateIndex measureId */

        script = 'create unique index if not exists "' || tablePrefix || '_i_F2AB6119FA3B0E0D0A9413F76CE42674CAD7CC12" on "' || schema || '"."' || tableNameNonQuoted || '" using btree ("Correlation_measureId" asc);';
        execute script;
/* PurgeObsoleteIndex */

/* PurgeObsoleteProperties */

for columnToDelete in
(
    select column_name
    from information_schema.columns
    where
        table_name = tableNameNonQuoted and
        column_name LIKE 'Correlation_%' and
        column_name <> 'Correlation_measureId'
)
loop
	script = '
alter table "' || schema || '"."' || tableNameNonQuoted || '"
drop column "' || columnToDelete || '"';
    execute script;
end loop;

/* CompleteSagaScript */

        return 0;
    end;
    $body$
language 'plpgsql';

select pg_temp.create_saga_table_SubscriberPolicySaga(@tablePrefix, @schema);
