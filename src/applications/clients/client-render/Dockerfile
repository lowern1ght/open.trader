FROM node:lts-jessie

ENV NODE_ENV=production

WORKDIR /usr/src/client-render

COPY . .

RUN npm install

RUN npm build

EXPOSE 6000

RUN chown -R node /usr/src/app

USER node

CMD ["npm", "preview"]