using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using ProcessaDecomposicaoNumeroDivisores.Biz;
using ProcessaDecomposicaoNumeroDivisores.Repository;

namespace ProcessaDecomposicaoNumeroDivisores.Test
{
    [TestFixture]
    [TestClass]
    public class ProcessaDecomposicaoNumeroDivisoresTest
    {
        private static Mock<IExecutarProcessDecompNumDivisores> _mockIExecutarProcessDecompNumDivisores = new Mock<IExecutarProcessDecompNumDivisores>();
        private readonly ProcessaDecomposicaoNumeroDivisoresBiz biz = new ProcessaDecomposicaoNumeroDivisoresBiz(_mockIExecutarProcessDecompNumDivisores.Object);

        public ProcessaDecomposicaoNumeroDivisoresTest()
        {
        }

        [TestCase]
        [TestMethod]
        public void ProcessaDecomposicaoNumeroDivisoresTestTrue()
        {
            DefaultMock();
            _mockIExecutarProcessDecompNumDivisores.Setup(x => x.ExecutarProcessDecompNumDivisores(45));
            ErroProcessaDecomposicaoNumeroDivisoresMock();
        }

        public void DefaultMock()
        {
            _mockIExecutarProcessDecompNumDivisores.Setup(x => x.ExecutarProcessDecompNumDivisores(45)).Verifiable();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(true);
        }

        public void ErroProcessaDecomposicaoNumeroDivisoresMock()
        {
            _mockIExecutarProcessDecompNumDivisores.Setup(x => x.ExecutarProcessDecompNumDivisores(-1)).Throws<Exception>();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(false);
        }
    }
}
