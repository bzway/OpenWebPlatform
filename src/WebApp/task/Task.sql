CREATE TABLE [dbo].Activity
    (
      [Id] [INT] NOT NULL
                 IDENTITY(1, 1) ,
      ParentId INT ,
      ES DATETIME ,
      EF DATETIME ,
      LS DATETIME ,
      LF DATETIME ,
      DU DECIMAL ,
      Name NVARCHAR(100) ,
      Slack DECIMAL,
    )
ON  [PRIMARY];
GO

 

CREATE TABLE [dbo].ActivityDependence
    (
      [Id] [INT] NOT NULL
                 IDENTITY(1, 1) ,
      ForwardActivityId INT ,
      BackwardActivityId INT ,
      DependenceType INT  , --FS:0,FF:1,SS:2,SF:3
    )
ON  [PRIMARY];
GO




