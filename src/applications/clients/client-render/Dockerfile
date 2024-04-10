FROM node:18-alpine

EXPOSE 4000
ENV NODE_ENV=production

WORKDIR /client-render

RUN npm i -g typescript vite

COPY . .

RUN npm i

#CMD ["npm", "run", "dev"]
CMD ["npm", "run", "preview"]