
/* TableNameVariable */

set @tableNameQuoted = concat('`', @tablePrefix, 'SubscriberPolicySaga`');
set @tableNameNonQuoted = concat(@tablePrefix, 'SubscriberPolicySaga');


/* DropTable */

set @dropTable = concat('drop table if exists ', @tableNameQuoted);
prepare script from @dropTable;
execute script;
deallocate prepare script;
