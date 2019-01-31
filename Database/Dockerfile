FROM microsoft/mssql-server-linux:2017-latest
ENV SA_PASSWORD=db_password
ENV ACCEPT_EULA=Y
COPY ./Database/entrypoint.sh ./
COPY ./Database/SqlCmdStartup.sh ./
COPY ./Database/SqlCmdScript.sql ./
RUN chmod +x ./SqlCmdStartup.sh
CMD /bin/bash ./entrypoint.sh
