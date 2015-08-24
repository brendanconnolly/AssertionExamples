using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestorTheBarbarianDemo;
using Shouldly;

namespace TestorShouldlyTests
{
    class shouldlySpecialsTests
    {
        [Test]
        public void multipleAsserts_Test()
        {
            var testor = new TestorTheBarbarian();

            //change either or both value(s) below to fail test
            var expectedText = "testor";
            var expectedHealth = 100;

            //Nunit does not support this in 2.X but similar functionality is in discussion for v3 (Assert.All)

            //shouldly syntax
            testor.ShouldSatisfyAllConditions(
                () => testor.Name.ShouldContain(expectedText),
                () => testor.Health.ShouldBe(expectedHealth)
                );
            //--> testor should satisfy all the conditions specified, but does not.
            //       The following errors were found...
            //-------------- - Error 1-------------- -
            //  testor.Name should contain "bugra" but does not
            //-------------- - Error 2-------------- -
            //  testor.Health should be 10 but was 100
            //-------------------------------------- -
        }

        [Test]
        public void timedResult_Test()
        {
            var testor = new TestorTheBarbarian();
            //set sleep to >1000 to fail test
            var sleepyTime = 500;

            //nunit closest option MaxTime attribute on the test method. 

            Should.CompleteIn(
                () => testor.Rest(sleepyTime), TimeSpan.FromSeconds(1)
                );
            //--> Task should complete in 00:00:01 but did not

        }
    }
}
