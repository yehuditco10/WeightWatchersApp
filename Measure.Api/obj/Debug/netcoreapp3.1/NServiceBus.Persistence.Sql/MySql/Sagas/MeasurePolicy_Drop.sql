
/* TableNameVariable */

set @tableNameQuoted = concat('`', @tablePrefix, 'MeasurePolicy`');
set @tableNameNonQuoted = concat(@tablePrefix, 'MeasurePolicy');


/* DropTable */

set @dropTable = concat('drop table if exists ', @tableNameQuoted);
prepare script from @dropTable;
execute script;
deallocate prepare script;
