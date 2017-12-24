//只需要定义一次组件和组件模板
//在任何页面上就可以用。

var tmpls = getText("tmpl.html");

function $tmpl(sele) {
    return $(tmpls).filter(sele).html();
}


Vue.component('todo-item', {
    props: ['todo'],
    template: $tmpl('#tmp1')
});

Vue.component('student-ui', {
    props: ['stu'],
    template: $tmpl('#student')
});
