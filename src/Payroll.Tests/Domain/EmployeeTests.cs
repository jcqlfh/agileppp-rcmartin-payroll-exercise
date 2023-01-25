using Xunit;
using Payroll.Domain;

namespace Payroll.Tests.Domain;

public class EmployeeTests
{
    [Fact]
    public void New_Employee_With_Empty_Name()
    {
        // Arrange
        var name = "";
        var address = "St Emplyee";
        var paymentType = PaymentType.Hourly;
        decimal paymentValue = 10;

        // Act
        Action instatiation = () => { var employee = new Employee(name, address, paymentType, paymentValue); };
        
        // Assert
        Assert.Throws<ArgumentNullException>(instatiation);
    }

    [Fact]
    public void New_Employee_With_Empty_Address()
    {
        // Arrange
        var name = "Emplyee";
        var address = "";
        var paymentType = PaymentType.Hourly;
        decimal paymentValue = 10;

        // Act
        Action instatiation = () => { var employee = new Employee(name, address, paymentType, paymentValue); };
        
        // Assert
        Assert.Throws<ArgumentNullException>(instatiation);
    }

    [Fact]
    public void New_Employee_With_Negative_PaymentValue()
    {
        // Arrange
        var name = "Emplyee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Hourly;
        decimal paymentValue = -10;

        // Act
        Action instatiation = () => { var employee = new Employee(name, address, paymentType, paymentValue); };
        
        // Assert
        Assert.Throws<ArgumentException>(instatiation);
    }

    [Fact]
    public void New_Employee_Hourly()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Hourly;
        decimal paymentValue = 10;
        decimal rate = 0;

        // Act
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Assert
        Assert.NotEqual(Guid.Empty, employee.Id);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
        Assert.Equal(rate, employee.Rate);
    }

    [Fact]
    public void New_Employee_Monthly()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Monthly;
        decimal paymentValue = 1000;
        decimal rate = 0;

        // Act
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Assert
        Assert.NotEqual(Guid.Empty, employee.Id);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
        Assert.Equal(rate, employee.Rate);
    }

    [Fact]
    public void New_Employee_Commisioned()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Commissioned;
        decimal paymentValue = 1000;
        decimal rate = 10;

        // Act
        var employee = new Employee(name, address, paymentType, paymentValue, rate);

        // Assert
        Assert.NotEqual(Guid.Empty, employee.Id);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
        Assert.Equal(rate, employee.Rate);
    }

    [Fact]
    public void New_Employee_Commisioned_With_No_Rate()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Commissioned;
        decimal paymentValue = 1000;

        // Act
        Action instatiation = () => { var employee = new Employee(name, address, paymentType, paymentValue); };
        
        // Assert
        Assert.Throws<ArgumentException>(instatiation);
    }
}