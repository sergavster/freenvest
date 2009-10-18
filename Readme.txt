Freenvest, a free toolset to assist investors in p2p-lending.

Copyright (c) 2009 Johann Deneux <johann.deneux@gmail.com>

Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

* Description

Peer-to-peer lending sites such as Microplace, Prosper, Lending Club, MyC4
allow private persons to lend money to small businesses and persons.

Investors are faced with problems such as keeping track of:
- their bids for loans,
- their loans,
- the risks associated to lending (defaults, exchange rate fluctuations when
  lending to other countries), and of
- the performance of their portfolio.

The goal of this project is to provide tools to assist investors in their
decisions.

* Requirements

In order to build the software from its source code, you need:
- the F# compiler version 1.9.6.16
- msbuild

* Content

The directory where this file is located should also contain the following
subdirectories:
- InterestRates, contains an F# library to compute interest rates and their
  effects on returns,
- MyC4, an application used to test InterestRates using data relevant to
  lending on the MyC4 platform (www.myc4.com).
  
