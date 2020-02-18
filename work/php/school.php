<?php
    $pageTitle = "school";
    include 'view/header.php';
    ?>

    <div class="container">
        <div id="duck" class="duck"></div>


        <div>
            <select id="json_name">
            <option value="1080">1080</option>
            <option value="1081">1081</option>
            <option value="1082">1082</option>
            <option value="1083">1083</option>
        </select>
        </div>

        <button id="fill_btn">clickme</button>

        <div id="table_container">

        </div>
    </div>

    <?php include 'view/footer.php';?>

    <script type="text/javascript" src="js/fetch.js"></script>
    <script type="text/javascript" src="js/duck.js"></script>
</body>


</html>