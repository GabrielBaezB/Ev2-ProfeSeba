# Ev2-ProfeSeba
Caso de Estudio 
Desarrollo de Servicio de Comunicaciones 
En base al caso de estudio descrito inicialmente, desarrollar el módulo de comunicaciones de
contenedores inteligentes determinado en la solución de software. 
Para lo cual, efectuar las siguientes implementaciones requeridas: 
1. Proyecto Modelo 
Generar un proyecto Class Library que incluya la implementación del modelo de Clases 
producto del análisis de la unidad 1.
Implementar el Patrón DAL, patron Singleton y factory que sustenta dicho modelo. Considerar 
la implementación de solo las Clases DAL requeridas por la aplicación de consola C#.
2. Aplicación de Consola C# (Servicio de Comunicaciones) 
Generar un proyecto de Aplicación de Consola C# que implemente el servicio de 
comunicaciones descrito en el caso de estudio
El Servicio debe escuchar peticiones por defecto en el puerto 2500, sin embargo, debe ser 
configurable sin requerir compilación
Cuando el Servicio reciba una petición desde un cliente (el cual representa un medidor de 
trafico o medidor de consumo), el cliente envía un mensaje inicial con la siguiente estructura:
fecha|nro_medidor|tipo
Donde:
fecha: Corresponde a la fecha actual del servidor con la estructura yyyy-MM-dd-HH-mm-ss 
donde el caracter – efectúa la separación entre cada componente 
nro_medidor: Donde debe ser un valor de los medidores posibles existentes en el servidor 
(debe controlar de manera estatica los medidores registrados en el servidor)
tipo: Puede tener dos valores posibles, trafico o consumoEl mensaje enviado debe tener una diferencia de fecha menor a 30 minutos con el servidor y 
debe pertenecer a un medidor que cumpla con el nro enviado y el tipo. Si todo es correcto el 
servidor debe enviar un mensaje que indica que está esperando una solicitud, la estructura 
del mensaje original es la siguiente:
fechaServidor|WAIT
Donde:
fechaServidor: Corresponde a la fecha actual del servidor con la estructura yyyy-MM-dd-HHmm-ss donde el caracter – efectúa la separación entre cada componente 
Ejemplo: 2019-01-01-04-02-00 
WAIT: Indica que el servidor se encuentra esperando peticiones
Una vez recibido dicho mensaje por el cliente, el medidor cliente debe comprobar que viene el 
comando WAIT en el mensaje, Si esto último se cumple debe enviar un mensaje de 
actualización de estado con la siguiente estructura:
nroSerie|fecha|tipo|valor | {estado} |UPDATE
Donde el carácter | se utiliza de separador entre cada valor. 
Descripción de los elementos del mensaje:
nroSerie: Corresponde al id del contenedor de tipo int que debe existir en el servidor.
Ejemplo: 1234 
fecha: Corresponde a la representación en texto de la fecha, la cual posee la estructura yyyyMM-dd-HH-mm-ss donde el caracter – efectúa la separación entre cada componente 
Ejemplo: 2019-01-01-04-02-00 
tipo: puede ser uno de los valores posibles, trafico o consumo
valor: Valor de 0 a 1000 que dependiendo del tipo corresponde a lo siguienteSi el tipo es de trafico, corresponde a la cantidad de vehículos, si es de tipo consumo 
corresponde al consumo actual del medidor
estado: Campo opcional, en el caso de venir en la estructura debe corresponder a los siguientes 
valores
-1: Error de lectura
0: OK
1: Punto de carga lleno
2: Requiere mantención preventiva
Cada medidor se conecta al servidor, envía el mensaje y se desconecta. Considerar que el 
Servidor debe ser capaz de responder peticiones de múltiples medidores simultáneamente. 
En caso de que la lectura anterior contenga algún parámetro erróneo, el servidor debe 
responder con la estructura:
fecha | nroSerie | ERROR
Donde:
fecha corresponde a la fecha actual en el formato descrito en el primer mensaje , nroSerie
representa el numero de serie del medidory ERROR es el texto error. luego cerrar la conexión.
En vista de que, actualmente no se cuenta con un motor de base de datos destinado para este 
prototipo, cada nueva lectura debe ser almacenada en un fichero trafico.txt para los 
medidores de trafico y consumo.txt para los medidores de consumo, ambos archivos deben 
estar ubicados en la ruta de ejecución del proyecto y debe persistir cada actualización de 
estado en formato JSON
3. Aplicación de Consola C# (Simulador de Medidor de trafico y consumo) 
Desarrollar una aplicación de consola C# que simule el comportamiento de un medidor de 
trafico o de consumo (ofrecer la selección de tipo de medidor al inicio de la aplicación), 
conectándose al servicio de comunicaciones (descrito en el punto 2), proporcionando nuevas 
actualizaciones de lecturas de cada medidor . Los valores de nroSerie, la fecha ,tipo, valor y
estado , deben ser entregados por medio de una interfaz provista por la aplicación.
