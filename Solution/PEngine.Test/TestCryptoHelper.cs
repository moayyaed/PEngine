using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using PEngine.Common.Components.Helpers;

namespace PEngine.Test
{
    class TestCryptoHelper
    {
        [Test]
        public void TestSha256()
        {
            var cases = new Dictionary<string, string>
            {
                {"abcdefghijklmnopqrstuvwxyz", "71c480df93d6ae2f1efad1447c66c9525e316218cf51fc8d9ed832f2daf18b73"},
                {"01234567890", "ee29eb4a8725678278ac439cf7abfd2a849cdc7378a6b6316017b81c51d720e7"},
                {"CfZ9C*?rx@7Rb!UK", "01804bcdc08b704bb22e6a3082451bfa93454782c5e5b2260fa3c44fc3e447ec"},
                {"Q7x6^&5uA%yu^-wG", "95304c530ad3fa1f00b7068ce9ad0144058c327694942178ccd06cf096581ee4"},
                {"Z8F8jLX+QhaahsXW", "d959b45886bfc540b8a82a8a614c1bd59e6998002d6f14927902ffa43bb866c7"}
            };

            foreach (var testCase in cases)
            {
                Assert.AreEqual(testCase.Value, CryptoHelper.Sha256(testCase.Key).ToLower());
            }
        }
    }
}
