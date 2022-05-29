CREATE PROCEDURE [dbo].[sp_FilterFunTranslations]
(
    @Text                   NVARCHAR(256) = NULL, 
    @Translation            NVARCHAR(32) = NULL, 
    @Translated             NVARCHAR(512) = NULL
)
AS
BEGIN
    SET NOCOUNT ON
    DECLARE
            @fText                   NVARCHAR(256), 
            @fTranslation            NVARCHAR(32), 
            @fTranslated             NVARCHAR(512)                  
        SET @fText                 = LTRIM(RTRIM(@Text))
        SET @fTranslation          = LTRIM(RTRIM(@Translation))
        SET @fTranslated           = LTRIM(RTRIM(@Translated))

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
        (@fText IS NULL OR [Text] LIKE '%' + @fText + '%')
    AND (@fTranslation IS NULL OR Translation LIKE '%' + @fTranslation + '%')
    AND (@fTranslated IS NULL OR Translated LIKE '%' + @fTranslated + '%')

    ORDER BY [Text]

END 
GO  