﻿CREATE PROCEDURE [dbo].[sp_FilterFunTranslations]
(
    -- Optional Filters for Filter - Dynamic Search
    @Id                     UNIQUEIDENTIFIER = NULL, 
    @Text                   NVARCHAR(256) = NULL, 
    @Translation            NVARCHAR(32) = NULL, 
    @Translated             NVARCHAR(512) = NULL
)
AS
BEGIN
    SET NOCOUNT ON
    DECLARE
            @fId                     UNIQUEIDENTIFIER, 
            @fText                   NVARCHAR(256), 
            @fTranslation            NVARCHAR(32), 
            @fTranslated             NVARCHAR(512)
        SET @fId                   = @fId                      
        SET @fText                 = LTRIM(RTRIM(@fText))
        SET @fTranslation          = LTRIM(RTRIM(@fTranslation))
        SET @fTranslated           = LTRIM(RTRIM(@fTranslated))

    SELECT
        Id,              
        [Text],
        Translation,     
        Translated,      
        CreatedBy,       
        CreatedDate,     
        LastModifiedBy,  
        LastModifiedDate
    FROM
        dbo.FunTranslates
    WHERE
        (@fId IS NULL OR Id = @fId)
    AND (@fText IS NULL OR [Text] LIKE '%' + @fText + '%')
    AND (@fTranslation IS NULL OR Translation LIKE '%' + @fTranslation + '%')
    AND (@fTranslated IS NULL OR Translated LIKE '%' + @fTranslated + '%')

    ORDER BY [Text]

END 
GO  