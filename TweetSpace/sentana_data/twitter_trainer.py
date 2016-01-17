import math
import ast
import nltk.data, nltk.tag
import nltk.classify.util
from nltk.classify import NaiveBayesClassifier
from nltk.corpus import twitter_samples
from nltk.tokenize import TweetTokenizer

##tagger = nltk.data.load(nltk.tag._POS_TAGGER)
##
##print "0"
##text = nltk.word_tokenize("And now for something completely different")
##print "1"
##print tagger.tag(text)
##print "2"

def word_feats(words):
    try:
        return dict([(word, True) for word in words])
    except TypeError:
        print words
    

def getTweetTokens(classification, toRead, info, tags):
    i=0
    tknzr = TweetTokenizer()

    with open(toRead) as f:
        content = f.readlines()

    c = 0

    for item in content:
        #adapt the list into python dictionary format
        content[c] = item.replace("null", "None")
        content[c] = content[c].replace("false", "False")
        content[c] = content[c].replace("true", "True")
        c+=1

    for i in range(len(content)):
        tweet = eval(content[i])["text"]
        tokenTweet = tknzr.tokenize(tweet)
        j = 0
        k = 0
        while j < (len(tokenTweet) - k):
            #print j
            if tokenTweet[j][0] == "#":
                tokenTweet[j] = tokenTweet[j][1:]
            elif tokenTweet[j][0] == "@":
                del tokenTweet[j]
                j-=1
                k+=1
            j+=1
            
        info.append((word_feats(tokenTweet), classification))

ids = twitter_samples.fileids()
neg = 0
pos = 1
negtweets = "negtweets.txt"
postweets = "postweets.txt"

#tags unused
neginfo = []
posinfo = []
negtags = []
postags = []
getTweetTokens('neg', ids[0], neginfo, negtags)
getTweetTokens('pos', ids[1], posinfo, postags)

##for i in range(2):
##    print str(posinfo[i])
##    print str(neginfo[i])

classifier = NaiveBayesClassifier.train(neginfo + posinfo)
filenameneg = "tweet-.txt"
filenamepos = "tweet+.txt"

def ellipse(x):
    return (1.0/10)*((max(100-0.0005*x**2, 0))**0.5)

def writeInfo(classification, filename, classifier, infotokens):
    c = 0
    target = open(filename, "w")
    cur = []

    for word in classifier.most_informative_features(2500):
        if classifier.classify(word_feats(word)) == classification and len(word[0]) > 2:
            if word[0][0] != "#":
                cur.append((word[0], max(ellipse(c), 0.01)))
                c+=1

    #print "lol"
    cur = sorted(cur, key=lambda cur: cur[0])
    #print "lol2"
    for item in cur:
        #print item
        target.write(item[0] + "\t" +  str(item[1]) + "\n")
                      
    
#print neginfo[0]

writeInfo('neg', filenameneg, classifier, neginfo)
writeInfo('pos', filenamepos, classifier, posinfo)

#print "program termination successful"

##    try:
##        neginfo.append((tknzr.tokenize(tweet), 'neg'))
##    except TypeError:
##        i = 0
##        #In some cases, the tweet is not processed as a string.
##        #This does not happen frequently so they can be ignored.
    
#neginfo[i][0] = tknzr.tokenize(neginfo[i][0])
    
##
##print type(neginfo)
##for i in range(5):
##    print neginfo[i]
##target = open(ids[pos], "r")
##with open(ids

##print content[4]
##print eval(content[4])
##print len(content)
##
##for i in range(20):
##    print eval(content[i])["text"]
