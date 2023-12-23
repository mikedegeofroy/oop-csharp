using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace ATM.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create table passwords
    (
        account_id  bigint primary key ,
        hash char(64) not null
    );

    create table accounts
    (
        account_id bigint primary key generated always as identity,
        balance bigint not null
    );

    create table operations
    (
        account_id bigint primary key,
        amount double precision not null
    );
    """;

protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table accounts;
    drop table operations;
    drop table passwords;
    """;
}