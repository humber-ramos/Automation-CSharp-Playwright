# # Automatizaci�n de Pruebas End-to-End con Playwright y Allure

Idiomas disponibles: [English](README.md) | [Espa�ol](README.es.md)<br>

Este proyecto demuestra una prueba automatizada end-to-end utilizando Microsoft Playwright en combinaci�n con xUnit y Allure. Simula el recorrido completo de un usuario en un sitio de comercio electr�nico de prueba (Demo Blaze).

## Tecnolog�as Utilizadas

- **C#**
- **Playwright** (para la automatizaci�n del navegador)
- **xUnit** (framework de pruebas)
- **Allure** (para reportes de prueba)
- **GitHub Actions** (para la integraci�n y entrega continua - CI/CD)

## Pasos que Realiza la Prueba

La prueba sigue los siguientes pasos para verificar si es posible realizar una orden en el sitio web:

**1.** Accede al sitio web (https://demoblaze.com/)<br>
**2.** Inicia sesi�n con una cuenta previamente creada<br>
**3.** Ingresa al carrito y elimina los productos (si los hay) para asegurar que la orden sea nueva<br>
**4.** Vuelve a la p�gina de inicio<br>
**5.** Selecciona la categor�a "Phones"<br>
**6.** Hace clic en el producto "Nokia lumia 1520" y lo agrega al carrito<br>
**7.** Vuelve a la p�gina de inicio<br>
**8.** Selecciona la categor�a "Phones"<br>
**9.** Se desplaza hacia abajo, hace clic en "HTC One M9" y lo agrega al carrito<br>
**10.** Vuelve a la p�gina de inicio<br>
**11.** Selecciona la categor�a "Laptops"<br>
**12.** Hace clic en "Sony vaio i7" y lo agrega al carrito<br>
**13.** Vuelve a la p�gina de inicio<br>
**14.** Selecciona la categor�a "Laptops"<br>
**15.** Se desplaza hacia abajo, hace clic en "McBook Pro" y lo agrega al carrito<br>
**16.** Vuelve a la p�gina de inicio<br>
**17.** Selecciona la categor�a "Monitors"<br>
**18.** Hace clic en "Apple monitor 24" y lo agrega al carrito<br>
**19.** Ingresa al carrito<br>
**20.** Elimina el producto "HTC One M9"<br>
**21.** Elimina el producto "McBook Pro"<br>
**22.** Hace clic en "Place Order"<br>
**23.** Llena el formulario de orden<br>
**24.** Hace clic en "Purchase"<br>
**25.** Verifica si aparece el mensaje "Thank you for your purchase!". Si aparece, la prueba pasa; si no, falla.<br>

## Modo Headless � Nota Importante

La prueba se ejecuta en **modo headless**, lo cual significa que el navegador se ejecuta en segundo plano, sin una interfaz visible. Esta configuraci�n fue necesaria para que GitHub Actions pudiera ejecutar la prueba en la nube.<br>
Si deseas cambiarlo, dir�gete al archivo "PlaywrightDriver.cs" en la carpeta "Drivers" y establece la opci�n "Headless" en "false".

## Reporte de Allure

Puedes ver el reporte completo generado por la ejecuci�n del pipeline en GitHub Actions en el siguiente enlace:

[**Haz clic aqu� para abrir el reporte de Allure**](https://humber-ramos.github.io/Automation-CSharp-Playwright/)

El reporte incluye:
- Estado de ejecuci�n de las pruebas
- Duraci�n de ejecuci�n y detalles del entorno

## Archivos Adicionales

El repositorio contiene una carpeta llamada "Running the test (videos)", ubicada en la ra�z del proyecto para mayor visibilidad. Esta carpeta incluye:
- Una **grabaci�n en video** de la ejecuci�n de la prueba
- **Im�genes est�ticas** del reporte de Allure

Esto es �til para una inspecci�n r�pida sin necesidad de abrir el reporte completo.<br>
El video se genera autom�ticamente cuando la prueba se ejecuta localmente. Para localizarlo, ve a la siguiente ruta:<br>
/bin/Debug/net9.0/videos

## Autor

Humberto Ramos  
Ingeniero de Automatizaci�n de Control de Calidad (QA)<br>
Conecta conmigo en [LinkedIn](https://www.linkedin.com/in/humberto-ramos-580121249/)