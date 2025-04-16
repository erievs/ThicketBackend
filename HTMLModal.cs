namespace ShittyVineRI {

    public static class HTMLModal {


        // you must use [https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/raw-string] to store html

        // https://github.com/jakiestfu/Ratchet-Vine

        
        public static String ExploreV2(String assetsURL) {
            
            if(assetsURL is null) {assetsURL = "localhost";};

            return $"""
        
            <!DOCTYPE html>
            <html data-lt-installed="true"><head>
            <meta http-equiv="content-type" content="text/html; charset=UTF-8">
                    <meta charset="utf-8">
                    <title>Ratchet template page</title>

                    <!-- Sets initial viewport load and disables zooming	-->
                    <meta name="viewport" content="initial-scale=1, maximum-scale=1, user-scalable=no">

                    <!-- Makes your prototype chrome-less once bookmarked to your phone's home screen -->
                    <meta name="apple-mobile-web-app-capable" content="yes">
                    <meta name="apple-mobile-web-app-status-bar-style" content="black">

                    <link rel="stylesheet" href="{assetsURL}/ratchet.css">
                    <link rel="stylesheet" href="{assetsURL}/snap.css">
                    <link rel="stylesheet" href="{assetsURL}/vine.css">

                <body>

                <div id="content">
                

                    <div class="content">
                        
                        <ul class="list main-list">
                            <li>
                                <a href="#">
                                    <strong>Editor's Picks</strong>
                                    <span class="chevron"></span>
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <strong>Popular Now</strong>
                                    <span class="chevron"></span>
                                </a>
                            </li>
                        </ul>
                
                        <div class="media-grid">
                            <div class="row">
                                <div class="one-third">
                                    <a href="#"><img src="{assetsURL}/95.gif"></a>
                                </div>
                                <div class="one-third">
                                    <a href="#"><img src="{assetsURL}/95.gif"></a>
                                </div>
                                <div class="one-third">
                                    <a href="#"><img src="{assetsURL}/95.gif"></a>
                                </div>
                            </div>
                            <div class="row">
                                <div class="one-third">
                                    <a href="#"><img src="{assetsURL}/95.gif"></a>
                                </div>
                                <div class="one-third">
                                    <a href="#"><img src="{assetsURL}/95.gif"></a>
                                </div>
                                <div class="one-third">
                                    <a href="#"><img src="{assetsURL}/95.gif"></a>
                                </div>
                            </div>
                        </div>
                
                        <div class="separator">Trending</div>
                        
                        <table class="link-table">
                            <tbody><tr>
                                <td><a href="#" class="block-link">#EarthDay</a></td>
                                <td><a href="#" class="block-link">#Monday</a></td>
                            </tr>
                            <tr>
                                <td><a href="#" class="block-link">#math</a></td>
                                <td><a href="#" class="block-link">#happyearthday</a></td>
                            </tr>
                            <tr>
                                <td><a href="#" class="block-link">#mondays</a></td>
                                <td><a href="#" class="block-link">#photography</a></td>
                            </tr>
                            <tr>
                                <td><a href="#" class="block-link">#class</a></td>
                                <td><a href="#" class="block-link">#LoPriore</a></td>
                            </tr>
                            <tr>
                                <td><a href="#" class="block-link">#Finals</a></td>
                                <td><a href="#" class="block-link">#model</a></td>
                            </tr>
                            <tr>
                                <td><a href="#" class="block-link">#Sunshine</a></td>
                                <td><a href="#" class="block-link">#CaliLife</a></td>
                            </tr>
                        </tbody></table>
                        
                    </div>
                </div>
                    
                    <script type="text/javascript" src="{assetsURL}/ratchet.custom.js"></script>
                    <script type="text/javascript" src="{assetsURL}/jquery.min.js"></script>
                    <script type="text/javascript" src="{assetsURL}/snap.js"></script>
                    <script type="text/javascript" src="{assetsURL}/app.js"></script>
  
                
            </body></html>
        
        
        """;

        }


    }

}