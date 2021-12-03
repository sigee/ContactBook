using System.Windows;
using Xunit;
using ContactBook.Helper;

namespace ContactBook.UnitTests.Helper
{
    public class NullToVisibilityConverterTest
    {
        [Fact]
        public void Convert_Null_ReturnsVisible()
        {
            var converter = new BoolToVisibilityConverter();
            var result = converter.Convert(false, null, null, null);
            Assert.Equal(Visibility.Collapsed, result);
        }
        
        [Fact]
        public void Convert_True_ReturnsVisible()
        {
            var converter = new BoolToVisibilityConverter();
            var result = converter.Convert(true, null, null, null);
            Assert.Equal(Visibility.Visible, result);
        }

        [Fact]
        public void Convert_False_ReturnsVisible()
        {
            var converter = new BoolToVisibilityConverter();
            var result = converter.Convert(false, null, null, null);
            Assert.Equal(Visibility.Collapsed, result);
        }
    }
}