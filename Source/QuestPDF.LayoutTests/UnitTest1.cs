using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.LayoutTests.TestEngine;

namespace QuestPDF.LayoutTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        LayoutTest
            .HavingSpaceOfSize(200, 400)
            .WithContent(content =>
            {
                content.Column(column =>
                {
                    column.Spacing(25);

                    column.Item().Mock("a", 150, 200);
                    column.Item().Mock("b", 150, 150);
                    column.Item().Mock("c", 150, 100);
                    column.Item().Mock("d", 150, 150);
                    column.Item().Mock("e", 150, 300);
                    column.Item().Mock("f", 150, 150);
                    column.Item().Mock("g", 150, 100);
                    column.Item().Mock("h", 150, 500);
                });
            })
            .ExpectedDrawResult(document =>
            {
                document
                    .Page()
                    .TakenAreaSize(400, 300)
                    .Content(page =>
                    {
                        page.Child("a").Position(0, 0).Size(250, 200);
                        page.Child("b").Position(150, 50).Size(50, 150);
                        page.Child("c").Position(200, 100).Size(100, 50);
                    });
                
                document
                    .Page()
                    .TakenAreaSize(400, 300)
                    .Content(page =>
                    {
                        page.Child("a").Position(0, 0).Size(150, 100);
                        page.Child("b").Position(250, 150).Size(50, 150);
                        page.Child("c").Position(300, 200).Size(100, 50);
                    });
            })
            .CompareVisually();
    }
    
    [Test]
    public void Test2()
    {
        LayoutTest
            .HavingSpaceOfSize(200, 200)
            .WithContent(content =>
            {
                content.Column(column =>
                {
                    column.Spacing(25);

                    column.Item().Mock("a", 150, 150);
                    column.Item().Mock("b", 125, 100);
                });
            })
            .ExpectedDrawResult(document =>
            {
                document
                    .Page()
                    .TakenAreaSize(150, 200)
                    .Content(page =>
                    {
                        page.Child("a").Position(0, 0).Size(150, 150);
                        page.Child("b").Position(0, 175).Size(125, 25);
                    });
                
                document
                    .Page()
                    .TakenAreaSize(125, 75)
                    .Content(page =>
                    {
                        page.Child("b").Position(0, 0).Size(125, 75);
                    });
            })
            .CompareVisually();
    }
}