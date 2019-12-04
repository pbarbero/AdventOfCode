using System.Collections.Generic;
using Xunit;
using AdventOfCode.Utils;

namespace AdventOfCode.UnitTests
{
    public class Day3Tests
    {
        [Fact]
        [Trait("Category", "Day3")]
        public void Test1()
        {
            var claims = BuildClaims();
            var inches = Claimeitor.GetNumberOverlappedClaims(claims);
            Assert.True(4 == inches);
        }

        [Fact]
        [Trait("Category", "Day3")]
        public void Test2()
        {
            var claims = BuildClaims();
            var id = Claimeitor.GetIsolatedClaim(claims);

            Assert.True("3" == id);
        }

        private List<Claim> BuildClaims()
        {
            return new List<Claim>()
            {
                new Claim()
                {
                    Id = "1",
                    MarginLeft = 1,
                    MarginTop = 3,
                    Width = 4,
                    Height = 4,
                },
                new Claim()
                {
                    Id = "2",
                    MarginLeft = 3,
                    MarginTop = 1,
                    Width = 4,
                    Height = 4,
                },
                new Claim()
                {
                    Id = "3",
                    MarginLeft = 5,
                    MarginTop = 5,
                    Width = 2,
                    Height = 2
                }
            };

        }
    }
}
