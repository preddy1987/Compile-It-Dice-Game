<template>
    <div id="news-feed">
        <VueRssFeed :feedUrl="feedUrl" :name="name" :limit="limit"/>
    </div>
</template>

<script>
import VueRssFeed from 'vue-rss-feed';

export default {
    name: 'news-feed-view',
    components: {
        VueRssFeed
    },
    data() {
        return {
        feedUrl: "https://fextralife.com/feed/",
        name: "",
        limit: 10,
        };
    }
}
</script>

<style>
#news-feed {
    height: 400px;
}
</style>
