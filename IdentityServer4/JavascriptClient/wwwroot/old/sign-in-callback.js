﻿//var callbackUrl = "https://localhost:44300/SignIn#id_token=eyJhbGciOiJSUzI1NiIsImtpZCI6IjF2WXNzaWdJOWlKb3NjV2k0MXlhY0EiLCJ0eXAiOiJKV1QifQ.eyJuYmYiOjE1OTMyNzE0MjQsImV4cCI6MTU5MzI3MTcyNCwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMDgiLCJhdWQiOiJjbGllbnRfaWRfanMiLCJub25jZSI6Ik5vbmNlVmFsdWVnYWRhc2RmbGJramFkc2ZmYWRsamhiYXNkMTIzIiwiaWF0IjoxNTkzMjcxNDI0LCJhdF9oYXNoIjoiUWJsQUdZbGpJWHJMdlNuRkdEM0JtZyIsInNfaGFzaCI6Ilc5SDdYN2pSWDdIX2I1X0YwdWRfcUEiLCJzaWQiOiJ0Y3lFdmk5UFBLRnFJYTJzV2YzckF3Iiwic3ViIjoiMTQ5YmYxMmEtMWIyYi00NGQ2LWE0YTUtNjMwZTQ1NTE4OTExIiwiYXV0aF90aW1lIjoxNTkzMjcxNDIzLCJpZHAiOiJsb2NhbCIsImFtciI6WyJwd2QiXX0.cKswV4mexgopc4rOlB8SMr2M8e7f1tcUEgFs68pxBxow3NFR4nue6Dp4r1MWT8ZhQEfagIgiJmRnchZ45zS5g2NKLMOOkEmVbbdiiKafjPvtIiXUWPSkexInBLV4oj1LXovfcMdB2r56BQVmx7DbN_iRj-NHttWqtVWcpQvudCj0Hi46yVWAtrRXM6iZ1fhiTYSfxtZqB0Po8kJRpAovsItOG_L-b1_pniN59KwqODIIvfaGRe3G917G1OGmoKFIo0waFk4ozgnp5PDsIKcBr5Gvp45-WjzUag5ZGA734sL48Gz3xXBQvmd0pKMr_Ngpd7A3BephDz4yiEB8okbsgA&access_token=eyJhbGciOiJSUzI1NiIsImtpZCI6IjF2WXNzaWdJOWlKb3NjV2k0MXlhY0EiLCJ0eXAiOiJhdCtqd3QifQ.eyJuYmYiOjE1OTMyNzE0MjMsImV4cCI6MTU5MzI3NTAyMywiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMDgiLCJhdWQiOiJBcGlPbmUiLCJjbGllbnRfaWQiOiJjbGllbnRfaWRfanMiLCJzdWIiOiIxNDliZjEyYS0xYjJiLTQ0ZDYtYTRhNS02MzBlNDU1MTg5MTEiLCJhdXRoX3RpbWUiOjE1OTMyNzE0MjMsImlkcCI6ImxvY2FsIiwicmMuYXBpLmdyYW5kbWEiOiJiaWcuYXBpLmNvb2tpZSIsInNjb3BlIjpbIm9wZW5pZCIsIkFwaU9uZSJdLCJhbXIiOlsicHdkIl19.SaGccucWCKdpfbLqkuK70_FyYaDURS6PeeP-YaDPgWylbPJ0E5QJDq2BYebJbOnjbnUKUf0o8zkYyqx1M8l17Y0NJUjD5mHcjuVl3lPWiDJ6y6EeKlzEfN-_ZOjsIpys_7MGwPs69tAfVjz0fWCKuPNcjtPuo0DsQzMFN4_LwNDnGmVFwDm7924MmWiN7Z36Qpoojkt7aVZQRKE1_64ZGic8-7CN_pig5CLVI-iCHsvlSljlsOVcb_8DfzrSePufaf3oKPe2yKBUVtz_jR4zxoSLNArlA6J17ghAIELdOFzooQaiAVhj8zhNYTSfzGL6pQe7RFeCRWdJ9TjTCIrXuA&token_type=Bearer&expires_in=3600&scope=openid%20ApiOne&state=SessionValuesssadfadfhiaofadlahdlfiuah&session_state=d1eETbgzrGMN_2R-oBcScJtBnrXAre6mzAllOyh62dU.p1TDRUTDSpynr4Tb01CDJw"

var extractTokens = function (callbackUrl) {

    var returnValue = callbackUrl.split('#')[1];
    var values = returnValue.split('&');

    for (var i = 0; i < values.length; i++) {
        var v = values[i];
        var kvPair = v.split('=');
        localStorage.setItem(kvPair[0], kvPair[1]);
    }

    console.log(returnValue);

    window.location.href = "/home/index";
}

extractTokens(window.location.href);