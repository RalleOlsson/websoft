<?php
    $pageTitle = "flag";
    include 'view/header.php';
    ?>

    <div class="container">


        <div id="content">
            <nav class="links_container">
                <a href="#" id="draw_sweden">Sweden</a>
                <a href="#" id="draw_denmark">Denmark</a>
                <a href="#" id="draw_france">France</a>
            </nav>

            
            <div id="flag_container">

            </div>
        </div>

        <div id="duck" class="duck"></div>

    </div>

    <?php include 'view/footer.php';?>

    <script src="js/flag.js"></script>
    <script src="js/duck.js"></script>
</body>

</html>