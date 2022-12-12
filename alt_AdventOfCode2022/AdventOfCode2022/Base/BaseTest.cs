using System;
namespace AdventOfCode2022.Base;

public abstract class BaseTest
{
    protected string Data { get; private set; }
    protected string TestData { get; private set; }
    protected string TestData2 { get; private set; }

    [SetUp]
    public void Setup()
    {
        var folder = this.GetType()?.Namespace?.Split(".")[1].Replace("_", "") ?? String.Empty;
        Data = File.ReadAllText($"{folder}/Data.in");
        TestData = File.ReadAllText($"{folder}/TestData.in");
        if(File.Exists($"{folder}/TestData2.in"))
            TestData2 = File.ReadAllText($"{folder}/TestData2.in");
    }

    [Test]
    public void DataIsNotNullOrEmpty()
    {
        Assert.That(Data, Is.Not.Null);
        Assert.That(Data, Is.Not.EqualTo(String.Empty));
    }

    [Test]
    public void TestDataIsNotNullOrEmpty()
    {
        Assert.That(TestData, Is.Not.Null);
        Assert.That(TestData, Is.Not.EqualTo(String.Empty));
    }
}