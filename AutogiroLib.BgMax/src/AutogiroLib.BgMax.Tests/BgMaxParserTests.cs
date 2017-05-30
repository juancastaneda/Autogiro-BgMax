namespace AutogiroLib.BgMax
{
    using System.Collections;
    using System.Collections.Generic;
    using Xunit;

    public class BgMaxParserTests
    {
        public class Given_I_have_an_empty_source
        {
            private Fixture fixture = new Fixture();

            public class When_I_process_the_source
            {
                private readonly Given_I_have_an_empty_source given =
                    new Given_I_have_an_empty_source();
                private readonly BgMaxRecord actual;

                public When_I_process_the_source()
                {
                    actual = given.fixture
                        .CreateSUT()
                        .ParseBgMaxContents();
                }

                [Fact]

                public void Then_I_should_get_an_instance()
                {
                    Assert.NotNull(actual);
                }
            }
        }

        public class Given_I_have_a_source_with_start_row
        {
            private Fixture fixture = new Fixture()
                .AddBgMaxContents(
                    "01BGMAX               0120160714173035010331P	                                "
                );

            public class When_I_process_the_source
            {
                private readonly BgMaxRecord actual;
                private readonly Given_I_have_a_source_with_start_row given =
                    new Given_I_have_a_source_with_start_row();
                
                public When_I_process_the_source()
                {
                    actual = given.fixture
                        .CreateSUT()
                        .ParseBgMaxContents();
                }

                [Fact]
                public void Then_I_should_get_an_instance_with_empty_avsnitt()
                {
                    Assert.NotNull(actual);
                    Assert.Empty(actual.Avsnitt);
                }


            }

        }

        private sealed class Fixture

        {
            private readonly List<string> bgMaxContents =
                new List<string>();
            public BgMaxParser CreateSUT()
            {
                return new BgMaxParser(BgMaxContentsAsEnumerable());
            }

            public Fixture AddBgMaxContents(params string[] lines)
            {
                bgMaxContents.AddRange(lines);
                return this;
            }

            public IEnumerable<string> BgMaxContentsAsEnumerable()
            {
                foreach (var line in bgMaxContents)
                {
                    yield return line;
                }
            }
        }
    }
}