using System.Collections.Generic;
using Infrastructure;
using NUnit.Framework;
using UnityEngine.UI;

namespace Editor.Tests
{
    public class HeartContainerTests
    {
        private Image fullImage;
        private Image emptyImage;
        private Heart fullHeart;
        private Heart emptyHeart;

        [SetUp]
        public void BeforeTest()
        {
            fullImage = An.Image().WithFillAmount(1);
            emptyImage = An.Image().WithFillAmount(0);

            fullHeart = A.Heart().With(fullImage);
            emptyHeart = A.Heart().With(emptyImage);
        }

        public class TheReplenishMethod : HeartContainerTests
        {
            [Test]
            public void _0_Sets_Image_With_0_Fill_To_0_Fill()
            {
                var heartContainer = new HeartContainer(new List<Heart> {emptyHeart});

                heartContainer.Replenish(0);

                Assert.That(emptyHeart.FilledHeartPieces, Is.EqualTo(0));
            }

            [Test]
            public void _1_Sets_Image_With_0_Fill_To_25_Percent_Fill()
            {
                var heartContainer = new HeartContainer(new List<Heart> {emptyHeart});

                heartContainer.Replenish(1);

                Assert.That(emptyImage.fillAmount, Is.EqualTo(0.25f));
            }

            [Test]
            public void Empty_Hearts_Are_Replenished()
            {
                var heartContainer = new HeartContainer(new List<Heart> {fullHeart, emptyHeart});

                heartContainer.Replenish(1);

                Assert.That(fullImage.fillAmount, Is.EqualTo(1));
                Assert.That(emptyImage.fillAmount, Is.EqualTo(0.25f));
            }

            [Test]
            public void _Hearts_Are_Replenished_In_Order()
            {
                var heartContainer = new HeartContainer(new List<Heart> {emptyHeart, fullHeart});

                heartContainer.Replenish(1);
                Assert.That(emptyHeart.FilledHeartPieces, Is.EqualTo(1));
            }

            [Test]
            public void _Distribute_Heart_Pieces_Across_Multiple_Unfilled_Hearts()
            {
                var oneEmptyPieceHeart = A.Heart().With(An.Image().WithFillAmount(0.75f));

                var heartContainer = new HeartContainer(new List<Heart> {oneEmptyPieceHeart, emptyHeart});

                heartContainer.Replenish(2);

                Assert.That(emptyHeart.FilledHeartPieces, Is.EqualTo(1));
            }
        }

        public class TheDepleteMethod : HeartContainerTests
        {
            [Test]
            public void _0_Sets_Full_Heart_To_Full_Heart()
            {
                var heartContainer = new HeartContainer(new List<Heart> {fullHeart});

                heartContainer.Deplete(0);

                Assert.That(fullHeart.FilledHeartPieces, Is.EqualTo(4));
            }

            [Test]
            public void _1_Sets_Full_Heart_To_Three_Quarters_Heart()
            {
                var heartContainer = new HeartContainer(new List<Heart> {fullHeart});

                heartContainer.Deplete(1);

                Assert.That(fullHeart.FilledHeartPieces, Is.EqualTo(3));
            }

            [Test]
            public void _2_Sets_Quarter_Heart_To_Zero_And_Full_Heart_To_Three_Quarters()
            {
                Heart oneQuarterHeart = A.Heart().With(An.Image().WithFillAmount(0.25f));
                var heartContainer = new HeartContainer(new List<Heart> {fullHeart, oneQuarterHeart});

                heartContainer.Deplete(2);

                Assert.That(oneQuarterHeart.FilledHeartPieces, Is.EqualTo(0));
                Assert.That(fullHeart.FilledHeartPieces, Is.EqualTo(3));
            }
        }
    }
}