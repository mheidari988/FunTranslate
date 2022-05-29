IF NOT EXISTS (SELECT 1 FROM [dbo].[FunTranslates])
BEGIN
	INSERT INTO [dbo].[sp_FilterFunTranslations]
	VALUES
	(N'abccdbc0-9276-4cae-74b4-08da4019c0ba', N'hello', N'Bello', N'minion', N'', N'2022-05-27 22:47:37', N'', NULL),
	(N'dbbd590f-14ba-4db5-9f2d-08da401a4d2a', N'I am hungry', N'ka am con a banana', N'minion', N'', N'2022-05-27 22:51:33', N'', NULL),
	(N'0ac31e64-a211-425d-0768-08da40940ebd', N'where are you?', N'where are you?', N'valspeak', N'', N'2022-05-28 13:23:07', N'', NULL),
	(N'295fb567-3f47-4cdd-8446-08da4099b7d4', N'hello my friend', N'Hodor hodor hodor', N'hodor', N'', N'2022-05-28 14:03:38', N'', NULL),
	(N'23cd461a-ac4c-4dd5-8447-08da4099b7d4', N'hello my friend', N'Force be with you my friend', N'yoda', N'', N'2022-05-28 14:03:59', N'', NULL),
	(N'b0843bfe-1678-4155-e2f7-08da409ce8d1', N'where are you?', N'You,  where are?', N'yoda', N'', N'2022-05-28 14:26:29', N'', NULL),
	(N'0a2bfe2c-f1ad-4a91-23e0-08da40a03402', N'where are you', N'You,  where are', N'yoda', N'', N'2022-05-28 14:50:03', N'', NULL),
	(N'2d8d6039-8200-4de6-d718-08da40a23b0c', N'hello', N'Force be with you', N'yoda', N'', N'2022-05-28 15:04:34', N'', NULL),
	(N'e7e04ce2-3656-42e9-ff95-08da40f08482', N'work', N'traba', N'minion', N'', N'2022-05-29 00:24:58', N'', NULL),
	(N'4c6589a2-5436-40aa-ff96-08da40f08482', N'you are a hero', N'Ao issi nykeā hero', N'valyrian', N'', N'2022-05-29 00:26:02', N'', NULL),
	(N'a24fac62-4741-4283-0ece-08da41548eb6', N'hello', N'Ahoy', N'pirate', N'', N'2022-05-29 12:21:05', N'', NULL),
	(N'c7adc4a8-8bee-4a09-6b37-08da415886d2', N'hello', N'ello-hay ', N'pig-latin', N'', N'2022-05-29 12:49:30', N'', NULL),
	(N'17f0aeff-ed9f-4481-6b38-08da415886d2', N'hello', N'hello', N'valspeak', N'', N'2022-05-29 12:49:43', N'', NULL);
END