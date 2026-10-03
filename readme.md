<div align="center">

<a href="https://fontmeme.com/es/fuentes-pixeladas/"><img src="https://fontmeme.com/permalink/261003/6a5fdf78.png" alt="fuentes-pixeladas" border="0"></a>


**Videojuego 2D arcade para escritorio, móvil y web.**
Esquiva tiburones, recoge medallas y aguanta el mayor tiempo posible.

[![Unity](https://img.shields.io/badge/Unity-6000.6.4f1-%23000000?style=for-the-badge&logo=unity&logoColor=white)](https://unity.com)
[![CSharp](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=dotnet&logoColor=white)](https://learn.microsoft.com/dotnet/csharp/)
[![Android](https://img.shields.io/badge/Android-3DDC84?style=for-the-badge&logo=android&logoColor=white)](https://developer.android.com)
[![Git](https://img.shields.io/badge/Git-F05032?style=for-the-badge&logo=git&logoColor=white)](https://git-scm.com)



</div>

---

## 📖 Descripción

Videojuego 2D arcade desarrollado en Unity. Controlas un pez que debe sobrevivir el
mayor tiempo posible en el océano: esquiva a los tiburones y estrellas, recoge medallas
para sumar puntos y consigue el récord antes de que se agote tu vida.

El fondo se mueve con un efecto *parallax* y la cámara sigue al personaje durante todo el
recorrido. Un único proyecto, compilado para **Windows y Android** desde el
mismo código, con controles de ratón y táctiles integrados en la misma build.

---

## 📑 Índice

- [🎮 Cómo se juega](#-cómo-se-juega)
- [⚙️ Mecánicas](#️mecánicas)
- [🛠️ Tecnologías utilizadas](#️-tecnologías-utilizadas)
- [🗂️ Estructura del proyecto](#️-estructura-del-proyecto)
- [🚀 Requisitos y ejecución](#-requisitos-y-ejecución)
- [👤 Autor](#-autor)
- [📅 Fechas del proyecto](#-fechas-del-proyecto)
- [⚖️ Licencia](#-licencia)
- [🔊 Créditos y recursos](#-créditos-y-recursos)

---

## 🎮 Cómo se juega

- **Escritorio:** clic izquierdo impulsa al pez hacia **arriba** (y empieza a nadar);
  clic derecho lo impulsa hacia **abajo**.
- **Móvil/tablet:** toca la **mitad superior** de la pantalla para subir y la **mitad inferior** para bajar.
- Si no pulsas, el pez cae por gravedad.

Empiezas en el menú (**PlayScene**) y pulsas **Jugar** para pasar a la partida (**GameScene**).

---

## ⚙️ Mecánicas

- **Vida:** barra de vida que baja al chocar con enemigos. Cuando baja de 20 el sonido se
  ralentiza (pez moribundo); al llegar a 0 es **Game Over**.
- **Enemigos (tiburones / estrellas):** quitan vida y se destruyen al impactar.
- **Recogibles (medallas):** suman puntos (cada medalla vale 5 puntos).
- **Generador:** crea enemigos y objetos aleatoriamente cada 5–7 segundos mientras el pez nada.
- **Game Over:** muestra la puntuación de la partida y el récord. El récord se guarda de forma
  local en `Application.persistentDataPath/registro.json` usando `JsonUtility` (compatible con
  IL2CPP, móvil y WebGL).

---

## 🛠️ Tecnologías utilizadas

### Motor y lenguaje

| Tecnología | Versión / detalle | Uso en el proyecto |
|---|---|---|
| **Unity** | `6000.6.4f1` (Unity 6.6) | Motor del juego, gestión de escenas, build y empaquetado |
| **C#** | .NET Standard 2.1 | Toda la lógica de juego (`Assets/Scripts`, 18 scripts) |
| **Unity Hub** | — | Gestión del proyecto y de los módulos de plataforma |
| **Git** | — | Control de versiones del proyecto |

### Gráficos y renderizado

| Tecnología | Detalle | Uso en el proyecto |
|---|---|---|
| **Built-in Render Pipeline** | Sin URP/HDRP | Renderizado 2D por defecto del proyecto |
| **2D Sprite** (`com.unity.2d.sprite`) | `1.0.0` | Sprites yecuta simple |
| **2D Animation** (`com.unity.2d.animation`) | `16.0.1` | Animaciones de personajes y enemigos |
| **2D Pixel Perfect** (`com.unity.2d.pixel-perfect`) | `6.0.0` | Escalado nítido del arte pixel art |
| **2D Tilemap** (`com.unity.2d.tilemap`) | `1.0.0` | Escenas de fondo |
| **2D SpriteShape** (`com.unity.2d.spriteshape`) | `16.0.0` | Elementos gráficos 2D |
| **PSD Importer** (`com.unity.2d.psdimporter`) | `15.0.1` | Importación del arte en PSD |
| **Timeline** (`com.unity.timeline`) | `6.6.0` | Secuencias y tiempos de animación |

### Física e interacción

| Tecnología | Detalle | Uso en el proyecto |
|---|---|---|
| **Unity 2D Physics** | `Rigidbody2D`, `Collider2D` | Gravedad, impulsos y detección de choques |
| `Rigidbody2D.linearVelocity` | API de Unity 6 | Control de la velocidad de nado |
| `AddForce` | — | Impulsos del pez al pulsar |
| `Physics2D` | — | Colisiones con tiburones y recogibles |

### Interfaz de usuario (UI)

| Tecnología | Detalle | Uso en el proyecto |
|---|---|---|
| **uGUI** (`com.unity.ugui`) | `2.6.0` | Canvas, botones, barra de vida y HUD |
| `UnityEngine.UI` | `Image`, `Text`, `Button` | Menú, barra de vida y Game Over |
| **TextMesh Pro** | Incluido en uGUI | Tipografía de la interfaz |

### Entrada multiplataforma

| Tecnología | Detalle | Uso en el proyecto |
|---|---|---|
| **Input Manager (clásico)** | `activeInputHandler: 0` | Un único código para ratón y táctil |
| `Input.GetMouseButtonDown` | Escritorio | Clic izquierdo = subir, clic derecho = bajar |
| `Input.touchCount` / `Input.GetTouch` | Móvil y tablet | Mitad superior / inferior de la pantalla |
| `Input.touchSupported` | — | Detección automática del dispositivo |

### Audio

| Tecnología | Detalle | Uso en el proyecto |
|---|---|---|
| **Audio System de Unity** | `AudioSource`, `AudioClip` | Música y efectos de sonido |
| `AudioSource.PlayClipAtPoint` | — | Sonidos posicionales de pickups y mordiscos |
| `AudioSource.pitch` | — | Efecto de "pez moribundo" (pitch `0.80`) |

### Datos y persistencia

| Tecnología | Detalle | Uso en el proyecto |
|---|---|---|
| **System.IO** | `File.ReadAllText` / `WriteAllText` | Lectura y escritura del récord |
| **JsonUtility** | `[Serializable]` | Serialización a `registro.json` (IL2CPP/WebGL/móvil) |
| `Application.persistentDataPath` | — | Ruta de guardado multiplataforma |

### Escenas y flujo de juego

| Tecnología | Detalle | Uso en el proyecto |
|---|---|---|
| **Scene Manager** | `SceneManager.LoadScene` | Menú → Juego → Game Over |
| **Eventos / coroutines** | `Invoke`, `StartCoroutine` | Tiempos de carga, parpadeo y aparición de objetos |
| **Random** | `Random.Range`, `Instantiate` | Generador aleatorio de enemigos y recogibles |
| **Materiales / shaders** | `Renderer.material` | Desplazamiento de textura del *parallax* |

### Herramientas de desarrollo

| Herramienta | Detalle |
|---|---|
| **Visual Studio / VS Code / Rider** | Paquetes `com.unity.ide.*` instalados para edición de código |
| **Unity Test Framework** | `com.unity.test-framework` `1.8.0` |
| **MCP for Unity** | `com.coplaydev.unity-mcp` — control del editor por IA durante el desarrollo |
| **Git + GitHub** | Versionado y publicación del repositorio |

---

## 🗂️ Estructura del proyecto

```
Assets/
├── Animations/   Animaciones y controladores (pez, tiburón, estrella, corazón)
├── Fonts/        Fuentes
├── Materials/    Materiales
├── Prefabs/      Personaje, enemigos, UI, cámara de Game Over...
├── Scenes/       PlayScene (menú) y GameScene (juego)
├── Scripts/      Lógica del juego (C#)
├── Sounds/       Música y efectos
├── Sprites/      Arte 2D
└── Textures/     Texturas
```

---

## 🚀 Requisitos y ejecución

- **Unity 6000.6.4f1** (Unity 6.6).
- Abrir el proyecto con Unity Hub y ejecutar la escena `Assets/Scenes/PlayScene.unity`.
- Plataformas soportadas por el código: **Windows / Mac / Linux (Standalone)**, **Android/iOS**
  y **WebGL**; actualmente con *Build Support* instalado para **Windows** y **WebGL**.
- Controles de teclado/ratón y táctiles incluidos en el mismo build.

---

## 👤 Autor

**Jorge Campos Rodriguez**

<a href="https://github.com/JCRodriguez93" target="_blank" rel="noopener noreferrer">perfil de github</a>

---

## 📅 Fechas del proyecto

- **Inicio del proyecto:** enero de 2022 (creación inicial del proyecto Unity).
- **Desarrollo principal:** octubre – diciembre de 2022 (escenas, personaje, enemigos,
  recogibles, interfaz y sonido).
- **Actualización actual:** 3 de octubre de 2026 — migración a **Unity 6000.6.4f1** (Unity 6),
  con los ajustes de API correspondientes (por ejemplo, `Rigidbody2D.velocity` → `linearVelocity`).

---

### Código fuente

El código fuente de **FishRace** es una obra propia de **Jorge Campos Rodriguez**,
realizada como proyecto académico del **Ciclo Formativo de Desarrollo de Aplicaciones
Multiplataforma (DAM)**. Se licencia bajo los términos de la licencia **MIT**, cuyo texto
completo se encuentra en el archivo [`LICENSE`](./LICENSE) de este repositorio.

> **Nota importante:** la licencia MIT cubre **únicamente el código fuente** escrito por el autor.
> Los recursos gráficos, sonoros y tipográficos son de terceros (ver abajo) y **no**
> se distribuyen bajo esta licencia.

### Recursos de terceros

Los fondos, personajes, sprites, animaciones, efectos de sonido, música y tipografías
empleados en el juego **no son obra propia**: son recursos de **uso libre descargados de
Internet** de bancos de arte y sonido gratuitos y de dominio público, seleccionados
específicamente para poder usarse y distribuirse en proyectos personales y educativos.

- **Fondos y texturas:** fondos submarinos y texturas de parallax descargados de bancos de
  imágenes de uso libre.
- **Personajes y enemigos:** sprites del pez, los tiburones, las estrellas y las medallas
  obtenidos de colecciones de sprites de uso libre.
- **Música y efectos de sonido:** pistas y efectos descargados de bibliotecas de audio
  gratuitas / dominio público (los ficheros de `Assets/Sounds` conservan en su nombre el
  sitio de origen, por ejemplo `mp3cut.net`).
- **Tipografías:** fuentes almacenadas en `Assets/Fonts` (`aAbstractGroovy`, `Kemco Smooth Bold`),
  igualmente de uso libre.

Cada recurso conserva su fichero original dentro de `Assets/` para poder rastrear su
procedencia. Este proyecto es **con fines educativos** dentro del ciclo formativo, por lo que
no se realiza con fines comerciales.

---

## 🔊 Créditos

- Script `NotificationCenter.cs` basado en el *NotificationCenter* de la
  [Unity Wiki](http://wiki.unity3d.com/index.php?title=NotificationCenterGenerics).
- Fuentes y arte de terceros: consultar la carpeta `Assets/Fonts` y `Assets/Sprites`.

---

<div align="center">

<sub>Hecho con Unity · Proyecto del Ciclo Formativo de DAM</sub>

</div>
