USE DB_MIGRATIONAPP;

IF OBJECT_ID ('dbo.usp_get_migrations_version', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_get_migrations_version;
GO
CREATE PROCEDURE dbo.usp_get_migrations_version
AS
    SET NOCOUNT ON;
    SELECT * FROM VersionInfo;
GO