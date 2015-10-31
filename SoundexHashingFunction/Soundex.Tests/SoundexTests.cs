using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoundexHashingFunction;

namespace SoundexTests
{
    [TestClass]
    public class SoundexTests
    {
        [TestMethod]
        public void RetainsSoleLetterOfOneLetterWord()
        {
            Assert.AreEqual("A000", Soundex.EncodeToSoundex("A"));
        }

        [TestMethod]
        public void PadsWithZeroesToEnsureThreeDigits()
        {
            Assert.AreEqual("I000", Soundex.EncodeToSoundex("I"));
        }

        [TestMethod]
        public void ReplacesConsonantBWithDigit1()
        {
            Assert.AreEqual("A100", Soundex.EncodeToSoundex("Ab"));
        }

        [TestMethod]
        public void ReplacesConsonantCWithDigit2()
        {
            Assert.AreEqual("A200", Soundex.EncodeToSoundex("Ac"));
        }

        [TestMethod]
        public void ReplacesTwoConsonantsWithAppropriateDigits()
        {
            Assert.AreEqual("A340", Soundex.EncodeToSoundex("Adl"));
        }

        [TestMethod]
        public void ReplacesThreeConsonantsWithAppropriateDigits()
        {
            Assert.AreEqual("A256", Soundex.EncodeToSoundex("Ajmr"));
        }

        [TestMethod]
        public void LimitsLengthToFourCharacters()
        {
            Assert.AreEqual("D123", Soundex.EncodeToSoundex("Dbcdlmr"));
        }

        [TestMethod]
        public void IgnoresVowelLikeLetters()
        {
            Assert.AreEqual("C123", Soundex.EncodeToSoundex("CAaEeIiOoUuHhYybcd"));
        }

        [TestMethod]
        public void CombinesDuplicateEncodings()
        {
            Assert.AreEqual("G123", Soundex.EncodeToSoundex("Gbfcgdt"));
        }

        [TestMethod]
        public void UppercasesFirst()
        {
            Assert.AreEqual("A123", Soundex.EncodeToSoundex("abcd"));
        }

        [TestMethod]
        public void ReplacesConsonantsWithAppropriateDigitsIgnoresCase()
        {
            Assert.AreEqual("B234", Soundex.EncodeToSoundex("BCDL"));
        }

        [TestMethod]
        public void DoesNotCombineDuplicateEncodingsSeparatedByVowels()
        {
            Assert.AreEqual("J110", Soundex.EncodeToSoundex("Jbob"));
        }

        [TestMethod]
        public void CombinesDuplicateCodesWhen2ndLetterDuplicates1st()
        {
            Assert.AreEqual("B230", Soundex.EncodeToSoundex("Bbcd"));
        }

        [TestMethod]
        public void CombinesDuplicateEncodingsSeparatedByHOrW()
        {
            Assert.AreEqual("J100", Soundex.EncodeToSoundex("Jbwb"));
        }
    }
}
