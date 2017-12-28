--清除用户 (必须清除登录记录和考试记录)
DELETE [dbo].[LoginInfo]--登录信息
DELETE FROM [dbo].[OperatePracticeErrorLog]--练习操作错误日志
DELETE FROM [dbo].[OperatePracticeRecord]--练习操作详细成绩记录
DELETE FROM [dbo].[OperateTestErrorLog]--考试操作错误日志
DELETE FROM [dbo].[OperateTestRecord]--考试操作详细成绩记录
DELETE [dbo].[OperatePracticeScoreRecords]----练习操作考试记录表
DELETE [dbo].[OperateTestScoreRecords]----考试操作考试记录表
DELETE [dbo].[PracticePaperRecordsQustion]--练习理论试卷表
DELETE [dbo].[TestPaperRecordsQustion]--考试理论试卷表
DELETE [dbo].[PracticePaperScoreRecords]--练习理论考试记录表
DELETE [dbo].[TestPaperScoreRecords]--考试理论考试记录表
DELETE [dbo].[User]WHERE [UserNo] NOT in('admin')
--清除题库
DELETE [dbo].[QuestionLibraryAnswer]--题库答案表
DELETE [dbo].[PracticePaperRecordsQustion]--练习理论试卷表
DELETE [dbo].[TestPaperRecordsQustion]--考试理论试卷表
DELETE [dbo].[QuestionLibrary]--题库问题表
--清除分组和单位
DELETE [dbo].[College]--单位表
DELETE [dbo].[Group]--分组表
--清除考试次数表
DELETE [dbo].[LoinTime] WHERE [flag]=1--清除考试次数
DELETE [dbo].[LoinTime] WHERE [flag]=0--清除练习次数


--清除指定题目
select * from QuestionLibrary where QuestionContent like'%中间辊道区保温装置位于粗轧与精轧之%'
delete PracticePaperRecordsQustion where QuestionLibraryId in(4953,4856,5225,5226,5063,5165,4790)
delete TestPaperRecordsQustion where QuestionLibraryId in(4953,4856,5225,5226,5063,5165,4790)


delete QuestionLibraryAnswer where QuestionId in(4953,4856,5225,5226,5063,5165,4790)
delete QuestionLibrary where id in(4953,4856,5225,5226,5063,5165,4790)
