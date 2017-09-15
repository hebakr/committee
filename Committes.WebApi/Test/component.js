angular.module('app', []);

angular.module('app').component('com', {
    templateUrl: '/test/component.html',
    controller: function ($interval) {
        var vm = this;

        vm.list = [];

        var counter = 0;

        vm.start = function () {
            $interval(function () {
                var live = _.filter(vm.list, function (item) { return item.killed === false; });
                if (live.length === 1) return;

                var currentIndex = _.findIndex(vm.list, function (o) { return o.current; });


                //find the next life 
                var index = _.findIndex(vm.list, function (o) { return o.killed === false; }, currentIndex+1);

                //kill him 
                vm.list[index].killed = true; 

                //path the sword to the next 
                var index2 = _.findIndex(vm.list, function (o) { return o.killed === false; }, currentIndex+1);

                vm.list[currentIndex].current = false;
                vm.list[index2].current = true;


            }, 1000);
        }


        vm.$onInit = function () {
            for (var i = 0; i < 100; i++) {
                var item = {
                    number: i + 1,
                    killed: false,
                    top: 0,
                    left: 0,
                    right: 0,
                    bottom: 0
                };

                if (i < 25) {
                    item.top = 0 + 'px';
                    item.left = i * 30 + 30 + 'px';
                } else if (i >= 25 && i < 50) {
                    item.left = 'auto';
                    item.right = 0 + 'px';
                    item.top = (i - 25 + 1) * 30 + + 1 + 'px';
                } else if (i >= 50 && i < 75) {
                    item.left = 'auto';
                    item.right = (i - 50 + 1) * 30 + 'px';
                    item.bottom = 0 + 'px';
                    item.top = 'auto';
                } else if (i >= 75) {
                    item.left = '0px';
                    item.top = 800 -  ((i - 75 +2) * 30) + 'px';
                }

                vm.list.push(item);

                vm.list[0].current = true;

            }

           
            vm.start();
        }


    },
    controllerAs: 'vm'
});