<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HoraCiudad.aspx.cs" Inherits="API_Hora.Pages.HoraCiudad" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Consulta Hora por Ciudad</title>

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <script type="text/javascript">
        function consultarHora() {
            var ciudad = $("#txtCiudad").val();

            if (ciudad.trim() === "") {
                alert("Debe ingresar una ciudad.");
                return;
            }

            $.ajax({
                url: "/api/hora/" + ciudad,   
                method: "GET",
                success: function (data) {
                    $("#resultado").html(
                        "<strong>Ciudad:</strong> " + data.Ciudad +
                        "<br><strong>Zona Horaria:</strong> " + data.ZonaHoraria +
                        "<br><strong>Hora Actual:</strong> " + data.HoraActual
                    );
                },
                error: function () {
                    $("#resultado").html("<span style='color:red'>Ciudad no encontrada.</span>");
                }
            });
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div style="width:400px; margin:auto; padding-top:40px; font-family:Arial">

            <h2>Consulta de Hora por Ciudad</h2>

            <label>Ciudad:</label><br />
            <input type="text" id="txtCiudad" class="form-control" placeholder="Ej: Santiago" />

            <br />
            <br />
            <button type="button" onclick="consultarHora()">Consultar</button>

            <hr />

            <div id="resultado" style="font-size:16px;"></div>

        </div>
    </form>
</body>
</html>