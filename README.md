# Proyecto de VR: Cyberwork 2077
### **Autores**:
- Florentín Pérez Glez.(alu0101100654)
- Adrián Emilio Padilla Rojas(alu0108558)
- Javier Duque Melguizo (alu0101160337)
- Eduardo Suarez Ojeda (alu0100896565)
# Índice
1. [Introducción](#id1)
2. [Aspectos del juego](#id2)
3. [Cuestiones importantes para el uso](#id3)
4. [Hitos de programación](#id4)
5. [Realización de la modificación](#id5)
6. [Conclusiones breves](#id6)


<div id='id1' />

## Introducción

El proyecto realizado se trata de un juego VR para dispositivos móviles Android al que hemos denominado ***CiberWork2077***. Se trata de un juego fundamentalmente de plataformas y exploración en la que el jugador deberá desenvolverse en distintos entornos hasta alcanzar la victoria, entendida esta como la finalización del juego en sí.

<div id='id2' />

## Aspectos del juego

El juego posee diversas implementaciones y características de interés que serán presentadas a continuación.
- Para jugar al juego hace falta el uso de un controlador compatible con **Bluetooth**. La cámara se desplaza acorde a la cabeza del usuario, mientras el desplazamiento se realiza a través de este dispositivo.
- Al iniciar la aplicación, el jugador se encontrará en un **menú** con distintas opciones. El menú está integrado con VR, por lo que se debe interactuar con el mismo a través de esta tecnología.
- El juego se puede dividir en **distintos niveles y/o mundos**. En cada uno de ellos se le plantea un desafío distinto al judador con objeto de suscitar distintas experiencias y fomentar positivamente la experiencia del usuario.
    - Cada mundo posee una **estética diferente**.
    - Cada mundo tiene sus **propios objetivos**.
    - El acceso a los mundos es **libre** y se puede realizar en el orden que se desee.
    - Al completar los mundos iniciales, se desbloquea un tercero que supone el **reto final** al usuario.
    - Los mundos son, respectivamente: **Bosque**, **Lava**, **Laberinto**.
- No existe manera alguna de perder al juego. En caso de no cumpliri los requisitos de alguno de los niveles desarrollados, el sistema dejará al usuario volver a intentarlo.
- A parte de desplazarse por tierra en cualquier dirección, el jugador también puede **saltar**. Esta es una mecánica fundamental para superar varias de las plataformas presentes a lo largo del videojuego.
- El juego ha sido implementado para ser compatible con **Google Cardoboard**, siguiendo las recomendaciones de diseño oficiales, hallables estas en la página oficial y respectiva a la tecnología.
- Se ha intentado en la medida de lo posible adaptar el juego a las recomendaciones dirigidas a faciltiar la integración del usuario en un entorno virtual.

<div id='id3' />


## Cuestiones importantes para el uso

Para comenzar a abarcar todas estas cuestiones, tenemos que tener en cuenta que tanto el desarrollo del juego, como su jugabilidad, han sido ideados para poder ser disfrutados mediante las carboard de google o cualquier otras gafas de RV que puedan suplir su misma función en un dispositivo móvil. Además, el uso de la mismas es indispensable, ya que la rotación de la cámara del personaje dependerá del eje de visión del jugador.

El otro elemento fundamentental será un mando. Su conexión al móvil debe ser posible a traves de bluethooth y, recomendablemente, debe ser de tipo PS4 o Xbox, ya que el botón que se emplea para realizar la opción de salto y movimiento por el menú principal ha sido ideada ser empleada por los botones más estandararizados para dichos mandos (X/A).

### Imagen de la configuración del mando
<p align="center">
<img src="images/ControllerLayout.png">
</p>

<div id='id4' />

## Hitos de programación
### **Mundo ***Bosque*****
### **Mundo ***Lava*****
En este mundo el jugador se encontrará en un entorno similar al crater de un volcán. En entorno, predominantemente rocoso, destaca por un elemento en concreto, ubicado este a los pies del jugador; un lago de lava ascendente que, de contactar con el jugador supondrá su derrota en el mundo (que podrá reintentar cuantas veces desee). Para superer este nivel, el usario deberá llegar a un portal de salida antes de que la lava lo engulla. Para ello, no le bastará con ser simplemente rápido, sino también hábil, ya que el usuario deberá ser capaz de superar varias plataformas correctamente si no quiere que un movimiento en falso provoque su precipitación sobre la lava.

Las plataformas mantienen todas formas distintas, además de las distancias de separación objeto de provocar variación a lo largo del desafío. Adicionalmente, algunas de ellas son móviles. Si el jugador llegara a colisionar con estas en su movimiento, se vería irremediablemente empujado a la lava.
## Aspectos que destacarías en la aplicación. Especificar si se han incluido sensores de los que se han trabajado en interfaces multimodales.

## Gif animado de ejecución

## Acta de los acuerdos del grupo respecto al trabajo en equipo: reparto de tareas, tareas desarrolladas individualmente, tareas desarrolladas en grupo, etc.
