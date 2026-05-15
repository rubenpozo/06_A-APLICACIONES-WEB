let display = document.getElementById("display");

    function agregar(valor) {
      if (display.innerText === "0") {
        display.innerText = valor;
      } else {
        display.innerText += valor;
      }
    }

    function limpiar() {
      display.innerText = "0";
    }

    function calcular() {
      try {
        display.innerText = eval(display.innerText);
      } catch {
        display.innerText = "Error";
      }
    }