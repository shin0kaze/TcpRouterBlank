
namespace TcpRouter.Abstractions.Tests
{
  public class ReadOnlyIPAddressTests
  {
    [TestCase("0.0.0.0", true)]
    [TestCase("1.1.1.1", true)]
    [TestCase("255.255.255.255", true)]
    [TestCase("255.255.255.256", false)]
    [TestCase("256.255.255.255", false)]
    [TestCase("0", false)]
    [TestCase("0,0,0,0", false)]
    [TestCase("test", false)]
    public void parsing_works_correctly(string ip, bool isValid)
    {
      if (isValid)
      {
        //���������, ��� ������� ������ � ip ������� �� ������ ������� ����������
        Assert.DoesNotThrow(() => ReadOnlyIPAddress.Parse(ip));
      }
      else
      {
        //���������, ��� ������� ������ � ip ������� ������� ����������
        Assert.Throws<FormatException>(() => ReadOnlyIPAddress.Parse(ip));
      }
    }
  }
}