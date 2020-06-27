var createState = function () {
    return "SessionValuesssadfadfhiaofadlahdlfiuah";
};

var createNonce = function () {
    return "NonceValuegadasdflbkjadsffadljhbasd123";
}

var signIn = function () {
    var redirectUri = "https://localhost:44300/Home/SignIn";
    var responseType = "id_token token";
    var scope = "openid ApiOne";
    var authUrl =
        "/connect/authorize/callback" +
        "?client_id=client_id_js" +
        "&redirect_uri=" + encodeURIComponent(redirectUri) +
        "&response_type=" + encodeURIComponent(responseType) +
        "&scope=" + encodeURIComponent(scope) +
        "&nonce=" + createNonce() +
        "&state=" + createState();


    var returnUrl = encodeURIComponent(authUrl);
    //var url = "Hello World";



    console.log(authUrl);
    console.log(returnUrl);

    window.location.href = "https://localhost:44308/Auth/Login?ReturnUrl=" + returnUrl;

 }