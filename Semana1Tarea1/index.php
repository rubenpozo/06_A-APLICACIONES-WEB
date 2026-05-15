<!DOCTYPE html>
<html lang="es-ES">
<head>
  <meta charset="UTF-8">
  <title>Calculadora</title>
  <link rel="stylesheet" href="estilos.css">
</head>
<body>
  <header>
    <h1>Universidad Regional Autónoma de Los Andes</h1>
    <img src="logo-uniandes.png" alt="Logo UNIANDES">
    <h2>Facultad de Sistemas Mercantiles</h2>
    <h3>Carrera de Ingeniería en Software</h3>
    <h3>Curso: Aplicaciones Web</h3>
    <h3>Tutor: Luis Antonio Llerena Ocaña</h3>
  </header>
  <div class="calculadora">
    <div id="display" class="display">0</div>
    <div class="botones">
      <button class="clear" onclick="limpiar()">AC</button>
      <button onclick="agregar('/')">/</button>
      <button onclick="agregar('*')">*</button>
      <button onclick="agregar('-')">-</button>

      <button onclick="agregar('7')">7</button>
      <button onclick="agregar('8')">8</button>
      <button onclick="agregar('9')">9</button>
      <button onclick="agregar('+')">+</button>

      <button onclick="agregar('4')">4</button>
      <button onclick="agregar('5')">5</button>
      <button onclick="agregar('6')">6</button>
      <button onclick="agregar('.')">.</button>

      <button onclick="agregar('1')">1</button>
      <button onclick="agregar('2')">2</button>
      <button onclick="agregar('3')">3</button>
      <button class="calcular" onclick="calcular()">=</button>

      <button class="espaciodoble" onclick="agregar('0')">0</button>
    </div>
  </div>
  <footer>
    <p>© 2026 Rubén Pozo. Todos los derechos reservados</p>
  </footer>
  <script src="scripts.js"></script>
</body>
</html>
