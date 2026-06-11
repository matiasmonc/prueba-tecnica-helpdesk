# Helpdesk Frontend

Esta aplicación es el frontend de un sistema de Helpdesk construida con React, Vite y TypeScript. Permite listar tickets, crear nuevos tickets y manejar validaciones con Formik + Yup.

## Estructura del proyecto

- `src/`
  - `App.tsx`: componente principal de la aplicación.
  - `main.tsx`: arranque de React.
  - `features/`
    - `Layout.tsx`: layout principal de la interfaz.
    - `tickets/`
      - `pages/`
        - `Ticket.tsx`: página principal de listado de tickets.
        - `AddTicket.tsx`: formulario para crear tickets.
      - `components/`: componentes de presentación para tickets.
      - `hooks/`: hooks personalizados para formularios y lógica.
      - `interfaces/`: tipos TypeScript para datos de ticket.
  - `api/`
    - `tickets.ts`: funciones para consumir el backend.
- `public/`: archivos estáticos.
- `index.html`: plantilla HTML principal.
- `tsconfig.json`: configuración de TypeScript.
- `vite.config.ts`: configuración de Vite.
- `package.json`: dependencias y scripts.

## Librerías y versiones

### Dependencias principales

- `react` ^19.2.6
- `react-dom` ^19.2.6
- `vite` ^8.0.12
- `typescript` ~6.0.2
- `tailwindcss` ^4.3.0
- `@tailwindcss/vite` ^4.3.0
- `formik` ^2.4.9
- `yup` ^1.7.1
- `sweetalert2` ^11.26.25
- `lucide-react` ^1.3.0

## Cómo está construido

- Vite se usa como bundler y servidor de desarrollo.
- React con TypeScript para la UI y tipado en tiempo de compilación.
- Tailwind CSS para estilos utilitarios.
- Formik para manejo de formularios.
- Yup para validación de formularios.
- SweetAlert2 para mostrar alertas de éxito o error.
- Fetch se usa para comunicarse con el backend.

## Pasos para ejecutar el proyecto

1. Instala dependencias:

```bash
yarn install
```

2. Inicia el servidor de desarrollo:

```bash
yarn dev
```

3. Abre la URL que indique Vite (por ejemplo `http://localhost:5173`).

4. Asegúrate de tener el backend disponible en `https://localhost:7019` o ajusta la URL en `src/api/tickets.ts`.

## Comandos disponibles

- `yarn dev`: inicia el servidor de desarrollo.
- `yarn build`: construye la app para producción.
- `yarn preview`: ejecuta la build resultante.
- `yarn lint`: ejecuta ESLint.

## Notas importantes

- Si usas SweetAlert2, importa su CSS en `main.tsx` o en el hook:

```ts
import "sweetalert2/dist/sweetalert2.min.css";
```

- El formulario `AddTicket` utiliza Formik + Yup para mantener validación y estado limpio.
- Los hooks sin JSX deben guardarse en archivos `.ts`, mientras que los componentes con JSX usan `.tsx`.
