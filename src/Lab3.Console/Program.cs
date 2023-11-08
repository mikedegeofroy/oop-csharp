using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Proxies;
using Itmo.ObjectOrientedProgramming.Lab3.User;

var message = new Message("Good morning!", "My body is ready.", Priority.High);
var user = new User();

var proxy2 = new MessageLogger(user, new Logger());
var proxy1 = new MessageFilter(proxy2);
proxy1.SetFilter(Priority.High);

proxy1.HandleMessage(message);