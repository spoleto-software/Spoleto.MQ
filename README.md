# Spoleto.MQ

SPOLETO message-broker based on RabbitMQ.

## Spoleto.MQ.Interfaces

The base library:  
https://github.com/spoleto-software/Spoleto.MQ/tree/main/src/Spoleto.MQ.Interfaces

## Spoleto.MQ.Publisher

The library for sending messages to a queue based on RabbitMQ:  
https://github.com/spoleto-software/Spoleto.MQ/tree/main/src/Spoleto.MQ.Publisher

There are two types how to send a message:
1. ``EasyRabbitPublisher`` - Publish/Subscribe pattern.
2. ``EasyRabbitSender`` - Send/Receive pattern.

## Spoleto.MQ.Subscriber

The library for receiving messages from a queue based on RabbitMQ:  
https://github.com/spoleto-software/Spoleto.MQ/tree/main/src/Spoleto.MQ.Subscriber

There are two types how to receive a message:
1. ``EasyRabbitSubscriber`` - Publish/Subscribe pattern.
2. ``EasyRabbitReceiver`` - Send/Receive pattern.