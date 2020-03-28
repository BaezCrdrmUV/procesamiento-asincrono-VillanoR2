# Procesamiento Asincrono

- ¿Qué es el procesamiento asíncrono?

El procesamiento asíncrono en un entorno de múltiples arrendatarios implica algunos retos:

## Garantizar la equidad del procesamiento

Asegúrese de que cada cliente dispone una parte equitativa de los recursos de procesamiento.

## Garantizar la tolerancia a errores

Asegúrese de que no se pierda ninguna solicitud asíncrona debido a errores del equipo o el software.

La plataforma usa un marco de procesamiento asíncrono basado en la cola. Este marco se usa para gestionar las solicitudes asíncronas para varias organizaciones en cada instancia. El ciclo de vida de una solicitud consta de tres partes:

## Inclusión en la cola

La solicitud se incluye en la cola. Puede ser una solicitud por lotes de Apex, una solicitud de Apex futuro o solicitudes de muchos otros tipos. La plataforma incluirá las solicitudes en la cola junto con los datos correspondientes para procesar las solicitudes.

## Persistencia

Una solicitud incluida en la cola es persistente. Las solicitudes se almacenan en un medio de almacenamiento persistente para garantizar la recuperación en caso de error y ofrecer la capacidad necesaria para las transacciones.

## Exclusión de la cola

La solicitud en la cola se elimina de la cola y se procesa. La transacción se gestiona en este paso para garantizar que los mensajes no se pierdan en caso de producirse un error de procesamiento.

Cada solicitud es procesada por un gestor. El gestor es el código que ejecuta las funciones necesarias para un tipo de solicitud específico. Los gestores se ejecutan mediante un número finito de subprocesos de trabajo en cada uno de los servidores de aplicaciones que componen una instancia. Los subprocesos requieren que el trabajo se desarrolle en el marco de la inclusión en cola y, tras la recepción, se inicia un gestor específico para ejecutar el trabajo.

### Conservación de recursos

El procesamiento asíncrono tiene una prioridad inferior en comparación con la interacción en tiempo real mediante el navegador y la API. Para garantizar que haya recursos suficientes para controlar un aumento de los recursos de computación, el marco de inclusión en cola monitorea los recursos del sistema, como la memoria del servidor y el uso de CPU, y reduce el procesamiento asíncrono cuando se superan los umbrales. Esta es una forma elaborada de decir que el sistema de múltiples arrendatarios se protege a sí mismo. Si una organización intenta “consumir” más recursos de los que le corresponden, el procesamiento asíncrono se suspende hasta que se alcanza un umbral normal. En resumen, no hay ninguna garantía por lo que respecta al tiempo de procesamiento, pero al final todo funciona correctamente.

- ¿En que escenarios se utiliza?
  
  1. En llamadas a servicios web
  2. Proesos remotos
  3. Limpiezas de datos
  4. Realizacion de operaciones de procesamiento secuenciales con servicios web externos.
  5. Tareas crónicas (que se hagan cada determinado tiempo, diarias o semanales)