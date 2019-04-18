<style>
[vswipe] {
  overflow: hidden;
  visibility: hidden;
  position: relative;
}
.swipe-wrap {
  overflow: hidden;
  position: relative;
}
</style>
<template>
  <div vswipe>
    <div class="swipe-wrap">
      <slot></slot>
    </div>
  </div>
</template>
<script>
import Swipe from "swipe-js-iso";
function noop() {}
export default {
  props: {
    options: {
      startSlide: { type: Number, default: 0 },
      speed: { type: Number, default: 400 },
      auto: { type: Number, default: 3000 },
      continuous: { type: Boolean, default: true },
      disableScroll: { type: Boolean, default: false },
      stopPropagation: { type: Boolean, default: false },
      callback: { type: Function, default: noop },
      transitionEnd: { type: Function, default: noop }
    }
  },
  data() {
    return {
      swipe: undefined
    };
  },
  mounted() {
    this.swipe = new Swipe(this.$el, this.options);
  },
  destroyed() {
    this.swipe.kill();
  },
  methods: {
    prev() {
      this.swipe.prev();
    },
    next() {
      this.swipe.next();
    },
    getPos() {
      return this.swipe.getPos();
    },
    getNumSlides() {
      return this.swipe.getNumSlides();
    },
    slide(index, duration) {
      this.swipe.slide(index, duration);
    },
    resize() {
      setTimeout(this.swipe.setup, 0);
    }
  }
};
</script>
<style>
html,
body,
div,
span,
object,
iframe,
h1,
h2,
h3,
h4,
h5,
h6,
p,
del,
dfn,
em,
img,
ins,
kbd,
q,
samp,
small,
strong,
b,
i,
dl,
dt,
dd,
ol,
ul,
li,
fieldset,
form,
label,
table,
tbody,
tfoot,
thead,
tr,
th,
td,
article,
aside,
footer,
header,
nav,
section {
  margin: 0;
  padding: 0;
  border: 0;
  outline: 0;
  font-size: 100%;
  vertical-align: baseline;
  background: transparent;
}
body {
  -webkit-text-size-adjust: none;
  font-family: sans-serif;
  min-height: 416px;
}
h1 {
  font-size: 33px;
  margin: 50px 0 15px;
  text-align: center;
  color: #212121;
}
h2 {
  font-size: 14px;
  font-weight: bold;
  color: #3c3c3c;
  margin: 20px 10px 10px;
}
small {
  margin: 0 10px 30px;
  display: block;
  font-size: 12px;
}
a {
  margin: 0 0 0 10px;
  font-size: 12px;
  color: #3c3c3c;
}

html,
body,
#app {
  height: 100%;
}

html,
body {
  background: #f3f3f3;
}

/* decorations */
.swipe-item b {
  display: block;
  font-weight: bold;
  color: #14ade5;
  font-size: 20px;
  text-align: center;
  margin: 10px;
  padding: 100px 10px;
  box-shadow: 0 1px #ebebeb;
  background: #fff;
  border-radius: 3px;
  border: 1px solid;
  border-color: #e5e5e5 #d3d3d3 #b9c1c6;
}
</style>
