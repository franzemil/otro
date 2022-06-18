use master;
GO
exec sp_attach_db bdtarija, '/usr/config/data/bdtarija.mdf', '/usr/config/data/bdtarija_log.ldf'
GO
