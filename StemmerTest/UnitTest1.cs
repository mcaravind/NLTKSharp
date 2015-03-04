using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLTKSharp;

namespace StemmerTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestSentenceTokenization()
        {
            string text = @"It's easy to understand for developers and 'plays well with everything'.
Don't underestimate the importance of toolchain support. Want to spin up a Ruby microservice which speaks HTTP? Sinatra and you're done. Go? Whatever the Go HTTP library is and you're done. Need to interact with it from the command line? Curl and you're done. How about from an automated testing script written in Ruby? Net:HTTP/HTTParty and you're done. Thinking about how to deploy it vis-a-vis firewall/etc? Port 80 and you're done. Need coarse-grained access logging? Built into Nginx/etc already; you're done. Uptime monitoring? Expose a /monitor endpoint; provide URL to existing monitoring solution; you're done. Deployment orchestration? Use Capistrano/shell scripts/whatever you already use for the app proper and you're done. Encrypted transport? HTTPS and you're done. Auth/auth? A few options that you're very well-acquainted with and are known to be consumable on both ends of the service trivially.
Edit to note: I'm assuming, in the above, that one is already sold on the benefits of a microservice architecture for one's particular app/team and is deciding on transport layer for the architecture. FWIW, I run ~4 distinct applications, and most of them are comparatively large monolithic Rails apps. My company's bookkeeping runs in the same memory space as bingo card PDF generation.
Things that would tilt me more towards microservices include a very rapid deployment pace, large engineering organizations which multiple distinct teams which each want to be able to control deploys/architecture decisions, particular hotspots in the application which just don't play well with one's main technology stack (as apparently happened in the app featured in this article), etc.";
            List<string> sentences = SentenceTokenizer.Tokenize(text);
            Assert.AreEqual(sentences.Count>2,true);
        }
        [TestMethod]
        public void TestStemming()
        {
            string word = "caresses";
            string stemmed = Stemmer.GetStem(word);
            Assert.AreEqual(stemmed,"caress");
        }
    }
}
