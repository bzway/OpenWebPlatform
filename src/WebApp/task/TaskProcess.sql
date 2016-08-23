IF OBJECT_ID('GetActivityList') IS NOT NULL
    BEGIN
        DROP PROC GetActivityList;
    END;
GO 
CREATE PROC GetActivityList
AS
    SELECT  *
    FROM    dbo.Activity
    WHERE   Id NOT IN ( SELECT  ParentId
                        FROM    dbo.Activity );

GO
IF OBJECT_ID('GetForwordActivityList') IS NOT NULL
    BEGIN
        DROP PROC GetForwordActivityList;
    END;
GO 
CREATE PROC GetForwordActivityList @ActivityId AS INT
AS
    SELECT  *
    FROM    dbo.Activity
    WHERE   Id IN ( SELECT  ForwardActivityId
                    FROM    dbo.ActivityDependence
                    WHERE   BackwardActivityId = @ActivityId ); 

GO
IF OBJECT_ID('GetBackwardActivityList') IS NOT NULL
    BEGIN
        DROP PROC GetBackwardActivityList;
    END;
GO 
CREATE PROC GetBackwardActivityList @ActivityId AS INT
AS
    SELECT  *
    FROM    dbo.Activity
    WHERE   Id IN ( SELECT  BackwardActivityId
                    FROM    dbo.ActivityDependence
                    WHERE   ForwardActivityId = @ActivityId ); 

