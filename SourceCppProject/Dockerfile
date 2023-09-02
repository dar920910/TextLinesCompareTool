FROM centos:latest

COPY . /usr/src/SendCodeLinesExplorer
WORKDIR /usr/src/SendCodeLinesExplorer

RUN yum -y group install "Development Tools"
RUN yum -y install cmake

RUN bash ./unix-app-build.bash

LABEL Name=SendCodeLinesExplorer Version=1.0.0