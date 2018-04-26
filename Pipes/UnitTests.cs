using NUnit.Framework;

namespace Pipes
{
    [TestFixture]
    class UnitTests
    {
        [Test]
        public void PipeCreateUp()
        {
            var pipe = new Pipe(Direction.Up, Color.Blue);
            Assert.AreEqual(Color.Blue, pipe.PipeColor);
            Assert.AreEqual(Direction.Up, pipe.MainOutletDirection);
            Assert.AreEqual(Direction.Right, pipe.RightOutletDirection);
        }

        [Test]
        public void PipeCreateDown()
        {
            var pipe = new Pipe(Direction.Down, Color.Blue);
            Assert.AreEqual(Color.Blue, pipe.PipeColor);
            Assert.AreEqual(Direction.Down, pipe.MainOutletDirection);
            Assert.AreEqual(Direction.Left, pipe.RightOutletDirection);
        }

        [Test]
        public void PipeCreateRight()
        {
            var pipe = new Pipe(Direction.Right, Color.Blue);
            Assert.AreEqual(Color.Blue, pipe.PipeColor);
            Assert.AreEqual(Direction.Right, pipe.MainOutletDirection);
            Assert.AreEqual(Direction.Down, pipe.RightOutletDirection);
        }

        [Test]
        public void PipeCreateLeft()
        {
            var pipe = new Pipe(Direction.Left, Color.Blue);
            Assert.AreEqual(Color.Blue, pipe.PipeColor);
            Assert.AreEqual(Direction.Left, pipe.MainOutletDirection);
            Assert.AreEqual(Direction.Up, pipe.RightOutletDirection);
        }

        [Test]
        public void TurnFromUp()
        {
            var pipe = new Pipe(Direction.Up, Color.Blue);
            pipe.Turn();
            Assert.AreEqual(Direction.Right, pipe.MainOutletDirection);
            Assert.AreEqual(Direction.Down, pipe.RightOutletDirection);
        }

        [Test]
        public void TurnFromDown()
        {
            var pipe = new Pipe(Direction.Down, Color.Blue);
            pipe.Turn();
            Assert.AreEqual(Direction.Left, pipe.MainOutletDirection);
            Assert.AreEqual(Direction.Up, pipe.RightOutletDirection);
        }

        [Test]
        public void TurnFromRight()
        {
            var pipe = new Pipe(Direction.Right, Color.Blue);
            pipe.Turn();
            Assert.AreEqual(Direction.Down, pipe.MainOutletDirection);
            Assert.AreEqual(Direction.Left, pipe.RightOutletDirection);
        }

        [Test]
        public void TurnFromLeft()
        {
            var pipe = new Pipe(Direction.Left, Color.Blue);
            pipe.Turn();
            Assert.AreEqual(Direction.Up, pipe.MainOutletDirection);
            Assert.AreEqual(Direction.Right, pipe.RightOutletDirection);
        }
    }
}
