# Estagio 1 - Será responsavel em construir nossa aplicação
FROM node:slim as node
WORKDIR /app
COPY compugraf-web/package.json compugraf-web/package-lock.json ./
RUN npm install
COPY ./compugraf-web .
ARG env=prod
RUN npm run build

# Estagio 2 - Será responsavel por expor a aplicação
FROM nginx
COPY --from=node /app/dist/compugraf-web /usr/share/nginx/html
COPY ./nginx.conf /etc/nginx/conf.d/default.conf