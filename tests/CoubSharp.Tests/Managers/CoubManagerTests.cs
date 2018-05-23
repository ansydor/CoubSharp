using CoubSharp.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoubSharp.Tests.Managers
{
    public class CoubManagerTests
    {
        [Fact]
        public async Task CoubManagerThrowsArgumentNullException()
        {
            var emptyToken = string.Empty;
            var sut = new CoubManager(emptyToken);
            await Assert.ThrowsAsync<ArgumentNullException>(()=>sut.GetCoubAsync(null));
        }

    }
}
