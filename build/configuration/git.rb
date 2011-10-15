configs ={
  :git => {
    :user => '20111017remote',
    :remotes => potentially_change("remotes",__FILE__),
    :repo => 'app'
  }
}
configatron.configure_from_hash(configs)
