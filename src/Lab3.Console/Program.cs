using Itmo.ObjectOrientedProgramming.Lab3.Filter;
using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Proxies;
using Itmo.ObjectOrientedProgramming.Lab3.User;

var message = new Message("Good morning!", "This is a body.", Priority.High);
var user = new User();
var logger = new Logger();
var filter = new PriorityFilter();
filter.SetFilter(Priority.High);

var proxy2 = new MessageLogger(user, logger);
var proxy1 = new MessageFilter(proxy2, filter);

proxy1.HandleMessage(message);