import { defineConfig } from 'vite';
import plugin from '@vitejs/plugin-react';
import tailwindcss from '@tailwindcss/vite'

export default defineConfig({
    plugins: [
        plugin(),
        tailwindcss(),
    ],
    server: {
        proxy: {
            '^/register': {
                target: 'http://localhost:7092',
                secure: false,
            },
            '^/login': {
                target: 'http://localhost:7092',
                secure: false,
            }
        },
        port: 3000,
    }
})
